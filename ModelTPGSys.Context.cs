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
    
    public partial class TPGSysEntities : DbContext
    {
        public TPGSysEntities()
            : base("name=TPGSysEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AchEntry> AchEntries { get; set; }
        public virtual DbSet<AchFile> AchFiles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CTLinking> CTLinkings { get; set; }
        public virtual DbSet<CTMasterInfo> CTMasterInfoes { get; set; }
        public virtual DbSet<CTTransmitter> CTTransmitters { get; set; }
        public virtual DbSet<ERO> EROes { get; set; }
        public virtual DbSet<EROAccountInfo> EROAccountInfoes { get; set; }
        public virtual DbSet<EROLinking> EROLinkings { get; set; }
        public virtual DbSet<FeeAdvance> FeeAdvances { get; set; }
        public virtual DbSet<FeeAdvanceDetail> FeeAdvanceDetails { get; set; }
        public virtual DbSet<FeeSplit> FeeSplits { get; set; }
        public virtual DbSet<MasterFeeAdvDetail> MasterFeeAdvDetails { get; set; }
        public virtual DbSet<MasterInfo> MasterInfoes { get; set; }
        public virtual DbSet<PendingFee> PendingFees { get; set; }
        public virtual DbSet<PendingFeeDetail> PendingFeeDetails { get; set; }
        public virtual DbSet<PendingFeeSource> PendingFeeSources { get; set; }
        public virtual DbSet<PendingFeeType> PendingFeeTypes { get; set; }
    }
}
