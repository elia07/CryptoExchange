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
    
    public partial class Withdrawal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Withdrawal()
        {
            this.Exchange = new HashSet<Exchange>();
        }
    
        public long xID { get; set; }
        public long xUserID { get; set; }
        public Nullable<long> xUserBankAccountID { get; set; }
        public System.DateTime xDate { get; set; }
        public int xAmount { get; set; }
        public byte xStatus { get; set; }
        public string xDescription { get; set; }
        public Nullable<System.DateTime> xSettlementDate { get; set; }
        public long xWithdrawalCost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exchange> Exchange { get; set; }
        public virtual User User { get; set; }
        public virtual UserBankAccount UserBankAccount { get; set; }
    }
}