﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finary.Core.Enumerations
{
    public enum WithdrawalType
    {
        [Display(Name = "نقدی")]
        Cash,
        [Display(Name = "پرفکت")]
        PerfectMoney

    }
}
