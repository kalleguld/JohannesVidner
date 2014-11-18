using System;
using System.Collections.Generic;
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

    class Publication
    {
        private readonly int _id;
        public int Id
        {
            get { return _id; }
        }

        private readonly string _name;
        public string Name
        {
            get { return _name; }
        }

        private readonly List<User> _users;

        public List<User> Users
        {
            get { return _users; }
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void RemoveUser(User user)
        {
            _users.Remove(user);
        }

        private readonly List<Edition> _editions;

        public List<Edition> Editions
        {
            get { return _editions; }
        }

        public void AddEdition(Edition edition)
        {
            _editions.Add(edition);
        }

        public void RemoveEdition(Edition edition)
        {
            _editions.Remove(edition);
        }

        public Publication(int id, string name)
        {
            _id = id;
            _name = name;
            _users = new List<User>();
            _editions = new List<Edition>();
        }
    }

    class Edition
    {
        public DateTime RunningStarted { get; set; }
        public int MaxMissingPages { get; set; }
        public bool Running { get; set; }
        public string Log { get; set; }
        public string Errormessage { get; set; }

        private readonly Publication _publication;
        public Publication Publication { get { return _publication; }}

        public Edition(Publication publication)
        {
            _publication = publication;
            _publication.AddEdition(this);
        }
    }
}
