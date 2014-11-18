using System.Collections.Generic;
using System.Linq;

namespace JohannesVidnerProject.Models
{
    public static class Service
    {
        static readonly TempBase Data = new TempBase();
        // TODO
        public static List<Publication> GetPublications()
        {
            return Data.Publications;
        }

        // TODO
        public static List<Edition> GetCurrentEditions()
        {
            var pubs = GetPublications();
            return pubs.Select(p => p.CurrentEdition()).ToList();
        }
    }
}
