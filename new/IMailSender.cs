using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace newx
{
    public interface IMailSender
    {
        Task SendAsync(string email, string content);
    }
}
