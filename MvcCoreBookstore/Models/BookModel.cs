using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcCoreBookstore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100,MinimumLength =5)]
        [Required(ErrorMessage ="Please enter the name of the book")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please enter the author name")]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 30)]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage ="Please enter the total number of pages")]
        [Display(Name ="Pages of Book")]
        public int? Pages { get; set; }
        public string Language { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
