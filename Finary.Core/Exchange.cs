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
    
    public partial class Exchange
    {
        public long xID { get; set; }
        public Nullable<long> xUserID { get; set; }
        public Nullable<long> xRialTransactionID { get; set; }
        public Nullable<long> xFacilitatorID { get; set; }
        public Nullable<long> xWithdrawalID { get; set; }
        public byte xExchangeType { get; set; }
        public string xApiRequestID { get; set; }
        public string xFormCurrency { get; set; }
        public string xToCurrency { get; set; }
        public double xFromAmount { get; set; }
        public double xToAmount { get; set; }
        public string xPaymentTXID { get; set; }
        public double xApiComission { get; set; }
        public double xApiComissionPercent { get; set; }
        public double xComission { get; set; }
        public double xComissionPercent { get; set; }
        public System.DateTime xDate { get; set; }
        public byte xStatus { get; set; }
        public System.DateTime xWatchDate { get; set; }
        public double xRefferalSharePercent { get; set; }
        public double xRefferalShare { get; set; }
    
        public virtual FacilitatorTransaction FacilitatorTransaction { get; set; }
        public virtual RialTransaction RialTransaction { get; set; }
        public virtual User User { get; set; }
        public virtual Withdrawal Withdrawal { get; set; }
    }
}