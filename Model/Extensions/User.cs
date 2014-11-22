using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class User
    {
        public bool HasPassword(string password)
        {
            return (password != null && password == PasswordText);
        }
    }
}
