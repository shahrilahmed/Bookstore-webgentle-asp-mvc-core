using Microsoft.AspNetCore.Mvc;
using MvcCoreBookstore.Models;
using MvcCoreBookstore.Repository;
using System;
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

        public ViewResult AddNewBook(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel book)
        {
            var id = await _bookRepository.AddNewBook(book);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddNewBook), new {isSuccess = true});
            }
            return View();
        }
    }
}
