using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcCoreBookstore.Models;
using MvcCoreBookstore.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreBookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository= null;

        public BookController(BookRepository bookRepository )
        {
            _bookRepository = bookRepository;
        }
        public async Task<IActionResult> GetAllBooks()
        {
            dynamic data = new System.Dynamic.ExpandoObject();
            data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }
        
        public List<BookModel> SearchBook(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public ViewResult AddNewBook(bool isSuccess = false, int bookId=0)
        {
            ViewBag.languageList = GetLanguages().Select(x=> new SelectListItem() { 
                Text = x.Text
            }).ToList();


            ViewBag.isSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel book)
        {
            if (ModelState.IsValid)
            {
                var id = await _bookRepository.AddNewBook(book);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.languageList = new SelectList(GetLanguages(),"Id","Text");
            ViewBag.isSuccess = false;
            ViewBag.BookId = 0;

            ModelState.AddModelError("", "Please check if all the required entries are provided");

            return View();
        }

        private List<LanguageModel> GetLanguages() {
            return new List<LanguageModel>()
            {
                new LanguageModel() { Id = 1, Text = "Bangla"},
                new LanguageModel() { Id = 2, Text = "English" },
                new LanguageModel() { Id = 3, Text = "Arabic" }
            };
        }
    }
}
