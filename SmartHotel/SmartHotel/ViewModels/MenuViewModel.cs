using SmartHotel.Mvvm.Commands;
using SmartHotel.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHotel.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public List<MenuItem> Menus { get; set; }
        public MenuViewModel()
        {
            Menus = new List<MenuItem>()
            {
               new MenuItem(){ Icon="ic_bed",Title="Book a room",ViewModelType= typeof(BookingViewModel)},
               new MenuItem(){ Icon="ic_key",Title="My room",ViewModelType= typeof(MyRoomViewModel)},
               new MenuItem(){ Icon="ic_beach",Title="Suggestions",ViewModelType= typeof(SuggesstionsViewModel)},
               new MenuItem(){ Icon="ic_bot",Title="Concierge",ViewModelType= typeof(ConciergeViewModel)},
               new MenuItem(){ Icon="ic_logout",Title="Logout",ViewModelType=null},
            };
            MenuItemSelectedCommand = new DelegateCommand<object>(MenuSelected);
        }

        public class MenuItem
        {
            public Type ViewModelType { get; set; }
            public string Icon { get; set; }
            public string Title { get; set; }
        }

        public DelegateCommand<object> MenuItemSelectedCommand { get; }
        public void MenuSelected(object param)
        {
            if (param is MenuItem menuItem)
            {
                if (menuItem.ViewModelType != null)
                {
                    NavigationService.NavigateToAsync(menuItem.ViewModelType);
                }
                else
                {
                    //logout
                }
            }
        }
    }
}
