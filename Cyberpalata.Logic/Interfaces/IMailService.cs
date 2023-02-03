using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IMailService
    {
        void SendMail(string emailTo,string subject, string body);
    }
}
