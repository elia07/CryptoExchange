using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finary.Models
{
    public class AvailableCurrencyModel
    {
        public AvailableCurrencyModel(string ticker, string name, string image, bool hasExternalId, bool isFiat, bool featured, bool isStable, bool supportsFixedRate)
        {
            this.ticker = ticker;
            this.name = name;
            this.image = image;
            this.hasExternalId = hasExternalId;
            this.isFiat = isFiat;
            this.featured = featured;
            this.isStable = isStable;
            this.supportsFixedRate = supportsFixedRate;
        }

        public AvailableCurrencyModel() { }

        public string ticker { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public bool hasExternalId { get; set; }
        public bool isFiat { get; set; }
        public bool featured { get; set; }
        public bool isStable { get; set; }
        public bool supportsFixedRate { get; set; }
    }


}