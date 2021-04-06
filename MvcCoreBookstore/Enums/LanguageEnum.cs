using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreBookstore.Enums
{
    public enum LanguageEnum
    {
        [Display(Name = "Hindi language")]
        Hindi = 1,
        [Display(Name = "English language")]
        English = 2,
        [Display(Name = "Bangla language")]
        Bangla = 3,
        [Display(Name = "German language")]
        German = 4,
        [Display(Name = "Chinese language")]
        Chinese = 5,
        [Display(Name = "Urdu language")]
        Urdu = 6
    }
}
