using System;

namespace Model
{
    public class Edition
    {
        public DateTime RunningStarted { get; set; }
        public int MaxMissingPages { get; set; }
        public bool Running { get; set; }
        public string Log { get; set; }
        public string Errormessage { get; set; }
        public int Pages { get; set; }

        private readonly Publication _publication;
        public Publication Publication { get { return _publication; }}

        public Edition(Publication publication)
        {
            _publication = publication;
            _publication.AddEdition(this);
        }
    }
}