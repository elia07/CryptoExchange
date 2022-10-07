using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finary.Models
{
    public class AddressValidationModel
    {


        public AddressValidationModel()
        {

        }

        public AddressValidationModel(bool result, string message)
        {
            this.result = result;
            this.message = message;
        }

        public bool result { get; set; }
        public string message { get; set; }
    }
}