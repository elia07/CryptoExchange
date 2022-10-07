using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finary.Core.Enumerations
{
    public enum SubscriptionType
    {
        [Display(Name = "ندارد")]
        None,
        [Display(Name = "ثبت نامی")]
        Register,
        [Display(Name = "ویژه")]
        VIP

    }
}
