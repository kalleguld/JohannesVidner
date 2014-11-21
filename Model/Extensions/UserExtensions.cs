using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Extensions
{
    public static class UserExtensions
    {
        public static bool HasPassword(this User user, string pass)
        {
            return user.PasswordText == pass;
        }
    }
}
