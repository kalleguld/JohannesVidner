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
        [Obsolete("Use publication.IsDescendant(parent)")]
        public bool IsDesendent(Publication child, Publication parent)
        {
            return child.IsDescendant(parent);
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
            User user = null;
            try
            {
                user = _dbContext.UserSet.FirstOrDefault(u => u.Username == username);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            if (user == null) return null;
            if (!user.HasPassword(password)) return null;
            return user;

        }

        public List<Publication> GetdescendantPublications(Publication parent)
        {
            var ans = new List<Publication>();
            AddChildrenRecursively(ans, parent);
            return ans;
        }

        private static void AddChildrenRecursively(ICollection<Publication> list, Publication pub)
        {
            list.Add(pub);
            foreach (var child in pub.ChildPublications.OrderBy(p => p.Name))
            {
                AddChildrenRecursively(list, child);
            }
        }

        public List<PublicationDepth> GetDescendantPublicationDepths(Publication parentPublication,
                                                                     Func<Publication, string> ordering = null)
        {
            if (ordering == null) ordering = p => p.Name;
            var ans = new List<PublicationDepth>();
            AddChildrenRecursively(ans, parentPublication, 0, ordering);
            return ans;
        }

        private static void AddChildrenRecursively(ICollection<PublicationDepth> list, Publication pub, int depth, Func<Publication, string> ordering)
        {
            list.Add(new PublicationDepth(pub, depth));
            foreach (var childPublication in pub.ChildPublications.OrderBy(ordering))
            {
                AddChildrenRecursively(list, childPublication, depth + 1, ordering);
            }
        }
    }
}
