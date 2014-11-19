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
        private readonly ModelClassesContainer _dbContext;
        

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
        /// Returns true if child is a child or grandchild of parent.
        /// </summary>
        public bool IsDesendent(Publication child, Publication parent)
        {
            while (true)
            {
                if (!child.ParentPublicationId.HasValue || child.ParentPublicationId.Value == child.Id)
                {
                    return false;
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

        // TODO: Should only return logged in users publications
        public List<Publication> GetPublications()
        {
            var pubes = _dbContext.PublicationSet.ToList();
            return pubes;
        }
    }
}
