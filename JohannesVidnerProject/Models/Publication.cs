using System;
using System.Collections.Generic;
using System.Linq;

namespace JohannesVidnerProject.Models
{
    public class Publication
    {
        public List<Edition> Editions { get; set; }
        public string Name { get; set; }

        public Publication(string name)
        {
            Name = name;
            Editions = new List<Edition>();
        }

        public Edition CurrentEdition()
        {
            return Editions.Last();
        }
    }

    public class Edition
    {
        public int Pages { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; }

        public Edition(int pages, DateTime time, string status)
        {
            Pages = pages;
            Time = time;
            Status = status;
        }
    }

    public class TempBase
    {
        public List<Publication> Publications { get; set; }
        public TempBase()
        {
            var temp = new List<Publication>();
            var p1 = new Publication("Jydske Vestkysten Kolding");
            var p2 = new Publication("Jydske Vestkysten Ribe");
            var p3 = new Publication("Jydske Vestkysten Tarm");
            var e1 = new Edition(31, new DateTime(), "Fejl! Sider mangler fandme!");
            var e2 = new Edition(32, new DateTime(), "Online");
            var e3 = new Edition(40, new DateTime(), "Online");
            p1.Editions.Add(e1);
            p2.Editions.Add(e2); 
            p3.Editions.Add(e3);
            temp.Add(p1);
            temp.Add(p2);
            temp.Add(p3);
            Publications = temp;
        }
    }
}
