﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moments.Data.MySqlDataSource.ORM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class momentsEntities : DbContext
    {
        public momentsEntities()
            : base("name=momentsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<person> people { get; set; }
        public DbSet<photo> photos { get; set; }
        public DbSet<phototag> phototags { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<friend> friends { get; set; }
        public DbSet<photopersonmapping> photopersonmappings { get; set; }
        public DbSet<photo1> photo1 { get; set; }
    }
}
