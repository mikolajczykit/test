using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace newx
{
    public class NotificationService
    {
        private readonly IMailSender _mailSender;
        private readonly IUserValidator _userValidator;

        public NotificationService(IMailSender mailSender, IUserValidator userValidator)
        {
            _mailSender = mailSender;
            _userValidator = userValidator;
        }

        public async Task NotifyUsersAsync(User user, string content)
        {
            if (_userValidator.ValidateUser(user))
            {
                await _mailSender.SendAsync(user.Email, content);
            }

            throw new InvalidOperationException();
        }


    }
}
