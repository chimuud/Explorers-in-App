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
    
    public partial class CTTransmitter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CTTransmitter()
        {
            this.CTLinkings = new HashSet<CTLinking>();
        }
    
        public int Id { get; set; }
        public string TransmitterEFIN { get; set; }
        public string LastEnrollYear { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string FaxPhone { get; set; }
        public string OfficePhone { get; set; }
        public string Website { get; set; }
        public System.DateTime RecordCreate { get; set; }
        public System.DateTime LastUpdate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTLinking> CTLinkings { get; set; }
    }
}