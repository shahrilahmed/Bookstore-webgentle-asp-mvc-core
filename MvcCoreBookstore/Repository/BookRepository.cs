using Microsoft.EntityFrameworkCore;
using MvcCoreBookstore.DB;
using MvcCoreBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreBookstore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel book)
        {
            var newBook = new Books()
            {
                Title = book.Title,
                Author = book.Author,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                Description = book.Description,
                Pages = book.Pages.HasValue? book.Pages.Value : 0,
                Language = book.Language
            };

            await _context.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var allBooks = await _context.Books.Select(
                x => new BookModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    Description = x.Description,
                    Pages = x.Pages,
                    Category = "test Cat",
                    Language = "test Lang"
                }
                ).ToListAsync();

            return allBooks;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.Where(x => x.Id == id).Select(x=> new BookModel {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                Description = x.Description,
                Pages = x.Pages,
                Category = x.Category,
                Language = x.Language
            }).FirstOrDefaultAsync();
            return book;
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title == title && x.Author == authorName).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Category="Category 1",Pages = 100, Language="English",Id=101,Title="Book 1",Author="Author 1", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras at mauris at nisl suscipit congue. Praesent nibh elit, semper vel gravida nec, faucibus sit amet leo. Mauris in pretium felis, a dictum tellus. Ut vehicula orci eget blandit sagittis. Pellentesque risus enim, pretium ac malesuada ac, volutpat in enim. Vivamus non quam ac mi pharetra vehicula quis id nisi. Pellentesque quis eleifend turpis, eget tincidunt mi. Aliquam laoreet nisi sit amet scelerisque laoreet. Suspendisse rutrum purus a malesuada tempor. Aliquam rutrum est diam, vitae scelerisque ligula porttitor non. Praesent vel augue a ex imperdiet dictum sit amet sit amet ipsum."},
                new BookModel(){Category="Category 2",Pages = 200, Language="English",Id=102,Title="Book 2",Author="Author 2", Description="Aenean pretium fringilla dapibus. Praesent dignissim augue eget pulvinar blandit. Nunc egestas lacus vel orci pulvinar, in commodo diam euismod. Fusce nec ornare mauris, et porttitor lacus. In ac leo elit. Sed aliquam sollicitudin eleifend. Vestibulum dapibus bibendum erat, nec semper magna vehicula eu. Praesent massa leo, sagittis sed ligula sed, elementum ornare est. Vivamus vestibulum lacus massa, at fringilla tortor cursus ut. Phasellus sit amet vestibulum augue."},
                new BookModel(){Category="Category 3",Pages = 300, Language="English",Id=103,Title="Book 3",Author="Author 3", Description="Phasellus ultricies aliquam nulla eu sagittis. Nam rutrum, massa vel facilisis aliquam, nisl metus iaculis ante, faucibus fringilla tortor urna eu odio. Nullam nulla lectus, tincidunt vitae nibh at, dignissim feugiat enim. Nunc in tempus dolor, ac dictum elit. Cras et erat quam. Proin a leo gravida, tempor enim vitae, fermentum nibh. Mauris feugiat in mi et convallis. Vestibulum vitae justo rutrum tellus malesuada laoreet a a libero. Aliquam molestie a eros vitae accumsan. Nunc mauris dui, viverra sit amet posuere ac, feugiat vel nibh. Pellentesque blandit pharetra libero, et mattis purus laoreet id. Fusce odio eros, sollicitudin eget leo sed, laoreet posuere dolor. Nullam tempus ipsum non mauris imperdiet fermentum. Suspendisse ut quam iaculis, vehicula orci vitae, varius lectus. Vivamus non lorem quis lacus volutpat dictum."},
                new BookModel(){Category="Category 3",Pages = 300, Language="English",Id=104,Title="Book 4",Author="Author 4", Description="Aliquam cursus odio id rhoncus porttitor. Suspendisse vel consequat odio. Vestibulum eu velit placerat, lobortis magna sed, scelerisque quam. Praesent tincidunt ut tortor eu lacinia. Vivamus varius blandit urna in iaculis. Duis sem dolor, volutpat vel velit sed, cursus aliquam massa. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Ut in magna vitae mauris sollicitudin pharetra. Integer vulputate augue quis lacus placerat interdum. Proin aliquam magna convallis mi posuere rhoncus. Donec scelerisque vitae ex eget ornare. Cras id dignissim arcu. Quisque placerat lorem congue purus blandit, pulvinar ullamcorper sem feugiat. Pellentesque non libero facilisis neque egestas ornare non facilisis risus. Curabitur feugiat risus enim, nec facilisis quam viverra eget. Suspendisse metus turpis, viverra id viverra posuere, imperdiet nec sem."},
            };
        }
    }
}
