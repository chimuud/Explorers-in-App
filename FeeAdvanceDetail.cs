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
    
    public partial class FeeAdvanceDetail
    {
        public int FeeAdvanceDetailId { get; set; }
        public int FeeAdvanceId { get; set; }
        public string TaxpayerId { get; set; }
        public decimal PrepFees { get; set; }
        public decimal PrepFeesAdvanced { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Lastupdate { get; set; }
    
        public virtual FeeAdvance FeeAdvance { get; set; }
    }
}