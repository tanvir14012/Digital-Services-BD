using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public interface IEmailService
    {
         Task<bool> SendEmailAsync(Email email);
    }
}
