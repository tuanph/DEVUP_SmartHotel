using SmartHotel.Mvvm;
using SmartHotel.Services.Navigation;
using System.Threading.Tasks;

namespace SmartHotel.ViewModels.Base
{
    public class ViewModelBase : BindableBase
    {
        private string _title;
        private bool _isBusy;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        protected INavigationService NavigationService;
        public ViewModelBase()
        {
            NavigationService = Locator.Instance.Reslove<INavigationService>();
        }
        public virtual Task InitializeAsync(object navigationData)// pre load data before 
        {
            return Task.CompletedTask;
        }
    }
}
