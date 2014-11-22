using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Extensions;

namespace Services
{
    public class DbService
    {
        private ModelClassesContainer _dbContext;
        private static DbService _instance;



        private DbService()
        {
            _dbContext = new ModelClassesContainer();
        }
        public static DbService Instance
        {
            get { return _instance ?? (_instance = new DbService()); }
        }

        public Publication GetPublicationById(int publicationId)
        {
            return _dbContext.PublicationSet.FirstOrDefault(pub => pub.Id == publicationId);
        }

        /// <summary>
        /// Returns true if child is a child or grandchild of parent, or if they are the same.
        /// </summary>
        public bool IsDesendent(Publication child, Publication parent)
        {
            if (child.Id == parent.Id)
            {
                return true;
            }
            while (true)
            {
                if (!child.ParentPublicationId.HasValue || child.ParentPublicationId.Value == child.Id)
                {
                    return false;
                }
                if (child.ParentPublicationId.Value == parent.Id)
                {
                    return true;
                }
                child = child.ParentPublication;
            }
        }

        public User GetUserById(int id)
        {
            return _dbContext.UserSet.FirstOrDefault(u => u.Id == id);
        }

        public User Create(User user)
        {
            _dbContext.UserSet.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public void Update(User user)
        {
            _dbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _dbContext.UserSet.Remove(user);
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var user = _dbContext.UserSet.FirstOrDefault(u => u.Username == username);
            if (user == null) return null;
            if (!user.HasPassword(password)) return null;
            return user;
        }

        public ICollection<Publication> GetPublications(User user)
        {
            var ans = new List<Publication>();
            var pub = user.Publication;
            AddChildrenRecursively(ans, pub);
            ans.RemoveAll(p => p.Editions.Count == 0);
            return ans;
        }

        private static void AddChildrenRecursively(ICollection<Publication> list, Publication pub)
        {
            list.Add(pub);
            foreach (var child in pub.ChildPublications)
            {
                AddChildrenRecursively(list, child);
            }
        }
    }
}
