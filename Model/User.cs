using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        private string _password;

        public User(string username, string password)
        {
            Username = username;
            _password = password;
        }
        public string Username { get; private set; }
        public string Name { get; set; }
        public string Mailaddress { get; set; }
        public string Password
        {
            set
            {
                _password = value;
                PasswordLastChanged = new DateTime();
            } 
        }
        public DateTime PasswordLastChanged { get; private set; }

        public bool HasWriteAccess { get; set; }
        public bool IsUserAdmin { get; set; }
        


        public bool IsPasswordCorrect(string password)
        {
            return _password != null && _password == password;
        }

        private Publication _publication ;
        public Publication Publication
        {
            get { return _publication; }
            set
            {
                _publication = value;
                _publication.AddUser(this);
            }
        }
    }
}
