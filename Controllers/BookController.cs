using LibraryApp.Context;
using LibraryApp.Entities;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _db;
        public BookController(LibraryContext db)
        {
            _db = db;
        }

        public IActionResult List()
        {
            var viewModel = _db.Books.Where(x => x.IsDeleted == false).Select(x => new BookListViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                PageCount = x.PageCount,
                AuthorFirstName = x.Author.FirstName,
                AuthorLastName = x.Author.LastName,
                BookType = x.BookType.Name
            }).ToList();

            return View(viewModel); // UNUTMAAAAAAAA !!
        }

        [HttpGet] // LİNKTEN TETİKLENEN
        public IActionResult Create()
        {
            ViewBag.Authors = _db.Authors
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.FirstName).ToList();

            ViewBag.BookTypes = _db.BookTypes
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.Name).ToList();

            return View();
        }

        [HttpPost] // FORMDAN TETİKLENEN
        public IActionResult Create(BookCreateViewModel formData)
        {

            var bookEntity = new BookEntity()
            {
                Name = formData.Name,
                PageCount = formData.PageCount,
                AuthorId = formData.AuthorId,
                BookTypeId = formData.BookTypeId,
            };

            _db.Books.Add(bookEntity);
            _db.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            var entity = _db.Books.Find(id);

            var viewModel = new BookUpdateViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                AuthorId = entity.AuthorId,
                BookTypeId = entity.BookTypeId,
                PageCount = entity.PageCount,
            };

            ViewBag.Authors = _db.Authors
              .Where(x => x.IsDeleted == false)
              .OrderBy(x => x.FirstName).ToList();

            ViewBag.BookTypes = _db.BookTypes
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.Name).ToList();

            return View(viewModel);

        }

        [HttpPost]
        public IActionResult Update(BookUpdateViewModel formData)
        {
            var entity = _db.Books.Find(formData.Id);

            entity.Name = formData.Name;
            entity.PageCount = formData.PageCount;
            entity.AuthorId = formData.AuthorId;
            entity.BookTypeId = formData.BookTypeId;
            entity.ModifiedDate = DateTime.Now;

            _db.Books.Update(entity);
            _db.SaveChanges();

            return RedirectToAction("List");

        }

        [HttpGet] // HTTPPOST ZANNEDİLİR FAKAT BİR FORMDAN TETİKLEME SÖZ KONUSU DEĞİL ! O NEDENLE HTTPGET
        public IActionResult Delete(int id)
        {
            var entity = _db.Books.Find(id);

            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;

            _db.Books.Update(entity);
            _db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
