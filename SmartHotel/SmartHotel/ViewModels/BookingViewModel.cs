using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SmartHotel.Mvvm.Commands;
using SmartHotel.Services.Hotel;
using SmartHotel.ViewModels.Base;

namespace SmartHotel.ViewModels
{
    public class BookingViewModel : ViewModelBase
    {
        IHotelService _hotelService;
        private string _search;
        private IEnumerable<Models.City> _cities;
        private IEnumerable<string> _suggestions;
        private string _suggestion;
        private bool _isNextEnabled;
        public BookingViewModel(IHotelService hotelService)
        {
            this._hotelService = hotelService;
            _cities = new List<Models.City>();
            _suggestions = new List<string>();
        }

        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                Filter(_search);

            }
        }
        public IEnumerable<string> Suggestions
        {
            get => _suggestions;
            set
            {
                _suggestions = value;
                OnPropertyChanged();
            }
        }
        public string Suggestion
        {
            get => _suggestion;
            set
            {
                SetProperty(ref _suggestion, value);
                IsNextEnabled = string.IsNullOrEmpty(_suggestion) ? false : true;
                //var dismissKeyboardService = DependencyService.Get<IDismissKeyboardService>();
                //dismissKeyboardService.DismissKeyboard();
            }
        }
        public bool IsNextEnabled
        {
            get => _isNextEnabled;
            set => SetProperty(ref _isNextEnabled, value);
        }

        public DelegateCommand NextCommand => new DelegateCommand(NextAsync);
        public override async Task InitializeAsync(object navigationData)
        {
            try
            {
                IsBusy = true;

                _cities = await _hotelService.GetCitiesAsync();

                Suggestions = new List<string>(_cities.Select(c => c.ToString()));
            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine($"[Booking Where Step] Error retrieving data: {httpEx}");

                if (!string.IsNullOrEmpty(httpEx.Message))
                {
                    await DialogService.ShowAlertAsync(
                        string.Format("HttpRequestExceptionMessage", httpEx.Message),
                        "HttpRequestExceptionTitle",
                        "Ok");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Booking Where Step] Error: {ex}");

                await DialogService.ShowAlertAsync(
                    "ExceptionMessage",
                    "Resources.ExceptionTitle",
                    "Resources.DialogOk");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void Filter(string search)
        {
            try
            {
                IsBusy = true;

                Suggestions = new List<string>(
                    _cities.Select(c => c.ToString())
                           .Where(c => c.ToLowerInvariant().Contains(search.ToLowerInvariant())));

                await Task.FromResult(0);
                //_analyticService.TrackEvent("Filter", new Dictionary<string, string>
                //{
                //    { "Search", search }
                //});
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Booking] Error: {ex}");
                //await DialogService.ShowAlertAsync(Resources.ExceptionMessage, Resources.ExceptionTitle, Resources.DialogOk);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void NextAsync()
        {
            var city = _cities.FirstOrDefault(c => c.ToString().Equals(Suggestion));

            if (city != null)
            {
                //await NavigationService.NavigateToAsync<BookingCalendarViewModel>(city);
                await Task.FromResult(0);
            }
        }
    }
}
