using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finary.Core.Enumerations
{
    public enum UserValidationProgress
    {
        [Display(Name = "ندارد")]
        None,
        [Display(Name = "سطح 1")]
        Level1,
        [Display(Name = "سطح 2")]
        Level2

    }
}
