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
    
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordText { private get; set; }
        public string Name { get; set; }
        public bool WriteAccess { get; set; }
        public bool UserAdminAccess { get; set; }
        public int PublicationId { get; set; }
    
        public virtual Publication Publication { get; set; }
    }
}
