using System;
using System.Collections.Generic;
using System.Text;

namespace newx
{
    public interface IUserValidator
    {
        bool ValidateUser(User user);
    }
}
