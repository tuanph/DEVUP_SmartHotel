using SmartHotel.Models;
using SmartHotel.Services.Suggestion;
using SmartHotel.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;

namespace SmartHotel.ViewModels
{
    public class SuggesstionsViewModel : ViewModelBase
    {
        private ObservableCollection<CustomPin> _customPins;
        private ObservableCollection<Suggestion> _suggestions;

        private readonly ISuggestionService _suggestionService;
        public SuggesstionsViewModel(ISuggestionService suggestionService)
        {
            _suggestionService = suggestionService;
        }

        public ObservableCollection<CustomPin> CustomPins
        {
            get { return _customPins; }
            set
            {
                _customPins = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Suggestion> Suggestions
        {
            get { return _suggestions; }
            set
            {
                _suggestions = value;
                OnPropertyChanged();
            }
        }


        public override async Task InitializeAsync(object navigationData)
        {
            try
            {
                IsBusy = true;

                //var location = await _locationService.GetPositionAsync();
                //Suggestions = await _suggestionService.GetSuggestionsAsync(location.Latitude, location.Longitude);
                Suggestions = await _suggestionService.GetSuggestionsAsync(40.762246, -73.986943);
                CustomPins = new ObservableCollection<CustomPin>();

                foreach (var suggestion in Suggestions)
                {
                    CustomPins.Add(new CustomPin
                    {
                        Label = suggestion.Name,
                        Position = new Position(suggestion.Latitude, suggestion.Longitude),
                        Type = suggestion.SuggestionType
                    });
                }
            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine($"[Suggestions] Error retrieving data: {httpEx}");

                //if (!string.IsNullOrEmpty(httpEx.Message))
                //{
                //    await DialogService.ShowAlertAsync(
                //        string.Format("HttpRequestExceptionMessage", httpEx.Message),
                //        "HttpRequestExceptionTitle",
                //        "DialogOk");
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Suggestions] Error: {ex}");

                //await DialogService.ShowAlertAsync(
                //    Resources.ExceptionMessage,
                //    Resources.ExceptionTitle,
                //    Resources.DialogOk);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
