//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class PendingFee
    {
        public long PendingFeeId { get; set; }
        public long PendingFeeSourceId { get; set; }
        public long AchEntryId { get; set; }
        public string Sadjkey { get; set; }
        public string Srecnum { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public string TraceNumber { get; set; }
        public bool FeeDisbursementInd { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
    
        public virtual PendingFeeSource PendingFeeSource { get; set; }
    }
}
