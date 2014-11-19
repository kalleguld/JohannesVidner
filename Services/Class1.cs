using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Services
{
    public class TestDb
    {
            public List<Publication> Publications { get; set; }

            public TestDb()
            {
                var temp = new List<Publication>();
                //var p1 = new Publication(123, "Jydske Vestkysten Kolding");
                //var p2 = new Publication(124, "Jydske Vestkysten Ribe");
                //var p3 = new Publication(125, "Jydske Vestkysten Tarm");
                //var e1 = new Edition(p1) {Errormessage = "Pages missing!"};
                //var e2 = new Edition(p2) {Running = true};
                //var e3 = new Edition(p3);
                //temp.Add(p1);
                //temp.Add(p2);
                //temp.Add(p3);
                Publications = temp;
            }
        }

    public static class TestService
    {
        static readonly TestDb TestData = new TestDb();

        // TODO: Should only return logged in users publications
        public static List<Publication> GetPublications()
        {
            return TestData.Publications;
        }

        // Returns a list of the current/newest edition of each publication.
        public static List<Edition> GetCurrentEditions()
        {
            var pubs = GetPublications();
            return pubs.Select(p => p.Editions.Last()).ToList();
        }

        public static string SetStatusColor(Edition e)
        {
            //var s = "publ good-publ";
            //if (!string.IsNullOrEmpty(e.Errormessage))
            //{
            //    s = "publ bad-publ";
            //}
            //if (e.Running)
            //{
            //    s = "publ warning-publ";
            //    e.Errormessage = "Running";
            //}
            //if (s == "publ good-publ")
            //{
            //    e.Errormessage = "Online";
            //}

            return null;
        }
    }
}
