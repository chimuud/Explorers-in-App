﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QA_Tools
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CORE_COPYEntities : DbContext
    {
        public CORE_COPYEntities()
            : base("name=CORE_COPYEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ADJ> ADJs { get; set; }
        public virtual DbSet<DISB> DISBs { get; set; }
        public virtual DbSet<RAL> RALs { get; set; }
        public virtual DbSet<COM> COMs { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<RISK> RISKs { get; set; }
    }
}