using System.Collections.Generic;
using System.Linq;

namespace JohannesVidnerProject.Models
{
    public static class Service
    {
        static readonly TempRepository Data = new TempRepository();

        // TODO: Should only return logged in users publications
        public static List<Publication> GetPublications()
        {
            return Data.Publications;
        }

        // Returns a list of the current/newest edition of each publication.
        public static List<Edition> GetCurrentEditions()
        {
            var pubs = GetPublications();
            return pubs.Select(p => p.CurrentEdition()).ToList();
        }
    }
}
