﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WebAuctionEntities : DbContext
    {
        public WebAuctionEntities()
            : base("name=WebAuctionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BanType> BanType { get; set; }
        public virtual DbSet<BetHistory> BetHistory { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Lot> Lot { get; set; }
        public virtual DbSet<LotProperty> LotProperty { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserInBan> UserInBan { get; set; }
        public virtual DbSet<UserInRole> UserInRole { get; set; }
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<EmailNotification> EmailNotification { get; set; }
        public virtual DbSet<EmailNotificationType> EmailNotificationType { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<PhotoInAlbum> PhotoInAlbum { get; set; }
        public virtual DbSet<StepBet> StepBet { get; set; }
    }
}