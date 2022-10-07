using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finary.Models
{
    public class CreateTransactionModel
    {
        public CreateTransactionModel(string payinAddress, string payoutAddress, string payoutExtraId, string fromCurrency, string toCurrency, string refundAddress, string refundExtraId, string id, double amount)
        {
            this.payinAddress = payinAddress;
            this.payoutAddress = payoutAddress;
            this.payoutExtraId = payoutExtraId;
            this.fromCurrency = fromCurrency;
            this.toCurrency = toCurrency;
            this.refundAddress = refundAddress;
            this.refundExtraId = refundExtraId;
            this.id = id;
            this.amount = amount;
        }

        public CreateTransactionModel() { }

        public string payinAddress { get; set; }
        public string payoutAddress { get; set; }
        public string payoutExtraId { get; set; }
        public string fromCurrency { get; set; }
        public string toCurrency { get; set; }
        public string refundAddress { get; set; }
        public string refundExtraId { get; set; }
        public string id { get; set; }
        public double amount { get; set; }
    }
}