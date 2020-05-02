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
    
    public partial class AchEntry
    {
        public long AchEntryId { get; set; }
        public int AchFileId { get; set; }
        public int AchEntryStatusId { get; set; }
        public int LineSequence { get; set; }
        public Nullable<System.DateTime> StatusDate { get; set; }
        public string SSN { get; set; }
        public int TransactionCode { get; set; }
        public string ReceivingDFIIdentification { get; set; }
        public int CheckDigit { get; set; }
        public string DFIAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string IndividualIdentificationNumber { get; set; }
        public string IndividualName { get; set; }
        public string DiscretionaryData { get; set; }
        public bool AddendaRecordIndicator { get; set; }
        public string TraceNumber { get; set; }
        public string Originator { get; set; }
        public string EffectiveDate { get; set; }
        public string FileDate { get; set; }
        public string SettlementDate { get; set; }
        public string ErrorMessage { get; set; }
        public string RawText { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime ModifyDate { get; set; }
    
        public virtual AchFile AchFile { get; set; }
    }
}
