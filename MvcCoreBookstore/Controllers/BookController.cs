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

        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public IActionResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }

        public ViewResult GetBook(int id)
        {
            var data = _bookRepository.GetBookById(id);
            return View(data);
        }
        
    }
}
