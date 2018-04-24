using SmartHotel.Mvvm;
using SmartHotel.Services.Dialog;
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
        protected IDialogService DialogService;
        public ViewModelBase()
        {
            NavigationService = Locator.Instance.Reslove<INavigationService>();
            DialogService = Locator.Instance.Reslove<IDialogService>();
        }
        public virtual Task InitializeAsync(object navigationData)// pre load data before 
        {
            return Task.CompletedTask;
        }
    }
}
