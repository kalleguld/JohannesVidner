using System.Collections.Generic;

namespace Model
{
    public class Publication
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
}