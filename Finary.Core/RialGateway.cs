//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Finary.Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class RialGateway
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RialGateway()
        {
            this.RialTransaction = new HashSet<RialTransaction>();
        }
    
        public long xID { get; set; }
        public string xName { get; set; }
        public byte xType { get; set; }
        public bool xIsActive { get; set; }
        public string xConfig { get; set; }
        public bool xIsPrimary { get; set; }
        public long xTodayTotalTransactionAmounts { get; set; }
        public System.DateTime xLastSuccessTransactionDate { get; set; }
        public double xComissionPercent { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RialTransaction> RialTransaction { get; set; }
    }
}
