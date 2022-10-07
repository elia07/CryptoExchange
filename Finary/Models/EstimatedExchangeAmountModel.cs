using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finary.Models
{
    public class EstimatedExchangeAmountModel
    {
        public EstimatedExchangeAmountModel(string estimatedAmount, string transactionSpeedForecast, string warningMessage)
        {
            this.error = "";
            this.estimatedAmount = estimatedAmount;
            this.transactionSpeedForecast = transactionSpeedForecast;
            this.warningMessage = warningMessage;
        }

        public EstimatedExchangeAmountModel()
        {
            this.error = "";
        }

        public EstimatedExchangeAmountModel(string estimatedAmount, string transactionSpeedForecast, string warningMessage, double networkFee)
        {
            this.error = "";
            this.estimatedAmount = estimatedAmount;
            this.transactionSpeedForecast = transactionSpeedForecast;
            this.warningMessage = warningMessage;
            this.networkFee = networkFee;
        }

        public EstimatedExchangeAmountModel(string error)
        {
            this.error = error;
        }

        public string estimatedAmount { get; set; }
        public string error { get; set; }
        public string transactionSpeedForecast { get; set; }
        public string warningMessage { get; set; }
        public double networkFee { get; set; }
    }

}