//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORM
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserInBan
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int BanType_Id { get; set; }
        public string Reason { get; set; }
    
        public virtual BanType BanType { get; set; }
        public virtual User User { get; set; }
    }
}