using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finary.Models
{
    public class TransactionStatusModel
    {
        public TransactionStatusModel(string status, string payinAddress, string payoutAddress, string fromCurrency, string toCurrency, string id, string updatedAt, double expectedSendAmount, double expectedReceiveAmount, string createdAt, bool isPartner)
        {
            this.status = status;
            this.payinAddress = payinAddress;
            this.payoutAddress = payoutAddress;
            this.fromCurrency = fromCurrency;
            this.toCurrency = toCurrency;
            this.id = id;
            this.updatedAt = updatedAt;
            this.expectedSendAmount = expectedSendAmount;
            this.expectedReceiveAmount = expectedReceiveAmount;
            this.createdAt = createdAt;
            this.isPartner = isPartner;
        }
        public TransactionStatusModel() { }

        public string status { get; set; }
        public string payinAddress { get; set; }
        public string payoutAddress { get; set; }
        public string fromCurrency { get; set; }
        public string toCurrency { get; set; }
        public string id { get; set; }
        public string updatedAt { get; set; }
        public double expectedSendAmount { get; set; }
        public double expectedReceiveAmount { get; set; }
        public string createdAt { get; set; }
        public bool isPartner { get; set; }
    }   
}