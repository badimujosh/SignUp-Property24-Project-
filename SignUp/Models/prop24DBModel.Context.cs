﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SignUp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class prop24Entities : DbContext
    {
        public prop24Entities()
            : base("name=prop24Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbAgent> tbAgents { get; set; }
        public virtual DbSet<tbSecurity> tbSecurities { get; set; }
        public virtual DbSet<tbProperty> tbProperties { get; set; }
        public virtual DbSet<tbLocation> tbLocations { get; set; }
    }
}
