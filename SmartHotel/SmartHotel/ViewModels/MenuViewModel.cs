using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHotel.ViewModels
{
    public class MenuViewModel
    {
        public List<MenuItem> Menus { get; set; }
        public MenuViewModel()
        {
            Menus = new List<MenuItem>()
            {
               new MenuItem(){ Icon="ic_bed",Title="Book a room"},
               new MenuItem(){ Icon="ic_key",Title="My room"},
               new MenuItem(){ Icon="ic_beach",Title="Suggestions"},
               new MenuItem(){ Icon="ic_bot",Title="Concierge"},
               new MenuItem(){ Icon="ic_logout",Title="Logout"},
            };

        }

        public class MenuItem
        {
            public string Icon { get; set; }
            public string Title { get; set; }
        }
    }
}
