using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finary.Core.Enumerations
{
    public enum RefferalWithdrawalStatus
    {
        [Display(Name = "در حال بررسی")]
        Waiting,
        [Display(Name = "رد شده")]
        Rejected,
        [Display(Name = "پرداخت شده")]
        Withdrawaled,

    }
}
