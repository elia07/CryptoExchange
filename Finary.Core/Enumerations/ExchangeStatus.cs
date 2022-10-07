using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finary.Core.Enumerations
{
    public enum ExchangeStatus
    {
        [Display(Name = "New")]
        New,
        [Display(Name = "waiting")]
        waiting,
        [Display(Name = "confirming")]
        confirming,
        [Display(Name = "exchanging")]
        exchanging,
        [Display(Name = "sending")]
        sending,
        [Display(Name = "finished")]
        finished,
        [Display(Name = "failed")]
        failed,
        [Display(Name = "refunded")]
        refunded,
        [Display(Name = "verifying")]
        verifying,
        [Display(Name = "expired")]
        expired
    }
}
