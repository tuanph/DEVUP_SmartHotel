using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHotel.Services
{
    public interface IEmailService
    {
        void Send(string email, string title, string content);
    }
}
