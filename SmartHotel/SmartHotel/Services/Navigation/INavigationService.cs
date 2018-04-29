using SmartHotel.ViewModels.Base;
using System;
using System.Threading.Tasks;

namespace SmartHotel.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync(bool isLogin);
        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;
        Task NavigateToAsync(Type viewModelType);
        Task NavigateToAsync(Type viewModelType, object parameter);
        Task NavigateBackAsync();
    }
}
