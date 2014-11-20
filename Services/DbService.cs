﻿using System;
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

        public User GetUserByUsernameAndPassword(string username,string password)
        {
            List<User> list = (_dbContext.UserSet.ToList().Where(u => u.Username == username && u.PasswordText == password)).ToList();

            if (list.Count != 0)
            {
                return list[0];
            }
            return null;
        }
        // TODO: Should only return logged in users publications
        public List<Publication> GetPublications()
        {
            var pubes = _dbContext.PublicationSet.ToList();
            pubes.RemoveAll(p => p.Editions.Count == 0);
            return pubes;
        }

        // maybe TODO: Change conditions for determining colors
        public string DetermineStatusColor(Publication p)
        {
            string s = "bad-publ";
            Edition e = p.Editions.Last();
            if (e.ErrorMessage.StartsWith("Success"))
            {
                s = "good-publ";
                e.ErrorMessage = "Online";
            }
            if (e.Running || e.ErrorMessage.StartsWith("Hold"))
            {
                s = "warning-publ";
                e.ErrorMessage = "Running";
            }
            return s;
        }

    }

    public class ColorComparer : IComparer<Publication>
    {
        public int Compare(Publication p1, Publication p2)
        {
            if (DbService.Instance.DetermineStatusColor(p1) == "bad-publ")
            {
                //DbService.Instance.DetermineStatusColor(p2) == "bad-publ";
            }
            return 0;
        }
    }
}
