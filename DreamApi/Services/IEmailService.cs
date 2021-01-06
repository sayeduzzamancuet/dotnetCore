using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamApi.Services
{
   public interface IEmailService
    {
        void sendEmail(string from,string to,string subject,string mailBody);
    }
}
