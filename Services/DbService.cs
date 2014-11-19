using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Services
{
    public class DbService
    {
        private static DbService _instance;

        private DbService()
        {
            //TODO 
        }
        public static DbService Instance
        {
            get { return _instance ?? (_instance = new DbService()); }
        }

        /// <summary>
        /// Returns all users assigned to the publication or a sub-publication
        /// </summary>
        public ICollection<User> GetUsersByPublicationRecursive(Publication publication)
        {
            throw new NotImplementedException();
        }

        public Publication GetPublicationById(int publicationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if child is a child or grandchild of parent.
        /// </summary>
        public bool IsDesendent(Publication child, Publication parent)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(string username, string password, string name, Publication publication)
        {
            throw new NotImplementedException();
        }
    }
}
