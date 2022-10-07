using Finary.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finary.Core.Models.DTO
{
    public class ExchangeDTO
    {
        public long? UserID { get; set; }
        public long? RialTransactionID { get; set; }
        public long? FacilitatorID { get; set; }
        public long? WithdrawalID { get; set; }
        public ExchangeType ExchangeType { get; set; }
        public string ApiRequestID { get; set; }
        public string FormCurrency { get; set; }
        public string ToCurrency { get; set; }
        public double FromAmount { get; set; }
        public double ToAmount { get; set; }
        public string PaymentTXID { get; set; }
        public double ApiComission { get; set; }
        public double ApiComissionPercent { get; set; }
        public double Comission { get; set; }
        public double ComissionPercent { get; set; }
        public double RefferalSharePercent { get; set; }
        public double RefferalShare { get; set; }
        public DateTime Date { get; set; }
        public DateTime WatchDate { get; set; }
        public ExchangeStatus Status { get; set; }
        public string RecipientWallet { get; set; }
        public string RefundWallet { get; set; }



    }
}
