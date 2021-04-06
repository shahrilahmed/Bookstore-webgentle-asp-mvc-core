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
        private readonly LanguageRepository _languageRepository = null;

        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
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

        public async Task<ViewResult> AddNewBookAsync(bool isSuccess = false, int bookId=0)
        {
            //    ViewBag.languageList = GetLanguages();

            ViewBag.languageList = new SelectList(await _languageRepository.GetAllLanguages(), "Id", "Name");
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
            ViewBag.languageList = new SelectList(await _languageRepository.GetAllLanguages(),"Id", "Name");
            //ViewBag.languageList = GetLanguages();
            ViewBag.isSuccess = false;
            ViewBag.BookId = 0;

            ModelState.AddModelError("", "Please check if all the required entries are provided");

            return View();
        }

        //private List<SelectListItem> GetLanguages() {

        //    var Group1 = new SelectListGroup() { Name = "Group 1" };
        //    var Group2 = new SelectListGroup() { Name = "Group 2" };
        //    var Group3 = new SelectListGroup() { Name = "Group 3" };

        //    return new List<SelectListItem>()
        //    {
        //        new SelectListItem() { Text = "Bangla", Value = "1", Group = Group1},
        //        new SelectListItem() { Text = "English", Value = "2", Group = Group1},
        //        new SelectListItem() { Text = "Arabic", Value = "3", Group = Group3 },
        //        new SelectListItem() { Text = "Hindi", Value = "4", Group = Group2},
        //        new SelectListItem() { Text = "Urdu", Value = "5", Group = Group3 }
        //    };
        //}
    }
}
