using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finary.Core.Enumerations
{
    public enum ExchangeType
    {
        [Display(Name = "C2C")]
        C2C,
        [Display(Name = "R2C")]
        R2C,
        [Display(Name = "C2R")]
        C2R
    }
}
