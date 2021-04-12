using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MvcCoreBookstore.Enums;
using MvcCoreBookstore.Helpers;
using Microsoft.AspNetCore.Http;

namespace MvcCoreBookstore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100,MinimumLength =5)]
        [Required(ErrorMessage ="Please enter the name of the book")]
        //[MyCustomValidation("mvc")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please enter the author name")]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 30)]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage ="Please enter the total number of pages")]
        [Display(Name ="Pages of Book")]
        public int? Pages { get; set; }
        [Required(ErrorMessage = "Please choose the languages of your book")]
        public int LanguageId { get; set; }
        public string Language { get; set; }
        [Required]
        [Display(Name ="Upload a cover photo of the book")]
        public IFormFile CoverPhoto { get;set;}
        [Display(Name = "Upload Gallery Images of the book")]
        public IFormFileCollection GalleryImages { get; set; }
        public string CoverImageUrl { get; set; }

        public List<GalleryModel> GalleryImgs { get; set; }
        //[Required(ErrorMessage = "Please choose the languages of your book")]
        //public LanguageEnum languageEnum { get; set; }
        [Display(Name = "Upload a PDF of the book")]
        public IFormFile PDF { get; set; }
        public string PDFUrl { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
