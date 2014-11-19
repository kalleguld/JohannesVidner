//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Publication
    {
        public Publication()
        {
            this.Editions = new HashSet<Edition>();
            this.Users = new HashSet<User>();
            this.Publications = new HashSet<Publication>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int PublicationId { get; set; }
    
        public virtual ICollection<Edition> Editions { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
        public virtual Publication PublicationParent { get; set; }
    }
}
