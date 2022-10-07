using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finary.Models
{
    public class MinExchangeAmountModel
    {
        public MinExchangeAmountModel(double minAmount)
        {
            this.minAmount = minAmount;
          
        }

        public MinExchangeAmountModel()
        {

        }

        public double minAmount { get; set; }
    }
}