using LibraryApp.Context;
using LibraryApp.Entities;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace LibraryApp.Controllers
{
    // BookType işleri (actionlar) bu alanda yapılacak -> BookTypeController
    public class BookTypeController : Controller
    {

        // -- > Bir class tetiklendiğinde içerisinde göreve hazır bir nesne gelsin istersek
        // --> Bir class içerisinde başka bir classa ait yapıları ( metot gibi ) kullanmak istersek
        // --> DEPENDENCY INJECTION kullanıyoruz.


        private readonly LibraryContext _db;
        public BookTypeController(LibraryContext db)
        {
            _db = db;
        }

        // BookType'a her istek atıldığında bir adet veritabanı kopyası ile gelmesini sağlıyorum.
        // Bu kopya nesneyi _db adında bir değişkene atıyorum.
        // _db üzerinden dbsetlere ve metotlara ulaşabiliyorum.
        // readonly -> değeri yalnızca constructorda değişebilir demek.



        [HttpGet] // LINK / URI ILE TETIKLENIR
        public IActionResult List()
        {

            //var bookTypes = _db.BookTypes;
            // BookTypes tablodaki her bir veriyi entity'e çevirip, bunların bir listesini oluşturdum.

            var bookTypes = _db.BookTypes.Where(x => x.IsDeleted == false);
            // Sistemimde soft delete işlemi olduğu için, artık tüm kitap türlerini değil yalnızca silinmemiş kitap türlerini çekiyorum.

            var viewModel = bookTypes.Select(x => new BookTypeListViewModel()
            {
                Id = x.Id,
                Name = x.Name

            }).ToList();

            // Her bir BookTypes elemanı (x) için bir tane BookTypeListViewModel oluşturuyorum. yeni oluşan modelin Id'sine BookTypes elemanının (x) Id'sini atıyorum. Name için de aynı işlem. Ardından bu yeni yapıyı bir listeye çeviriyorum ve aşağıda view'e göndereceğim.

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateForm");  
        }

        [HttpPost] // FORM'daki buttondan tetiklenen.
        public IActionResult Create(BookTypeCreateViewModel formData)
        {

            var entity = new BookTypeEntity()
            {
                Name = formData.Name
            }   ;

            _db.BookTypes.Add(entity); // kopyaya ekle
            _db.SaveChanges(); // orijinali güncelle.


    


            return RedirectToAction("List"); // Liste actionına gönderiyorum. İçerisindeki kodlar çalışacak.

            
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            var entity = _db.BookTypes.Find(id);
            // id ile eşleşen satırın bütün bilgilerini çekip bir entity olarak getirir.

            var updateViewModel = new BookTypeUpdateViewModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
            // Entitydeki tüm bilgilere viewde ihtiyacım olmadığı için yalnızca ihtiyacım olacakları taşıyacak bir viewModel oluşturdum.

            return View("UpdateForm",updateViewModel);
        }

        [HttpPost]
        public IActionResult Update(BookTypeUpdateViewModel formData)
        {
            var entity = _db.BookTypes.Find(formData.Id);

            entity.Name = formData.Name;
            entity.ModifiedDate = DateTime.Now;

            _db.BookTypes.Update(entity);
            _db.SaveChanges();

            return RedirectToAction("List");
            return View("List");

            // Redirect ve View arasındaki farka dikkat !
        }

        // Delete işlemi hep HttpPost zannedilse de bir formu olmadığı için ve yalnızca link ile tetiklendiği için --> HTTPGET
        public IActionResult Delete(int id)
        {

            var entity = _db.BookTypes.Find(id);


            // HARD DELETE --> Veri tamamen sistemden silinir.
            //_db.BookTypes.Remove(entity);
            //_db.SaveChanges();

            // SOFT DELETE
            entity.IsDeleted = true; // SilindiMi = evet !

            // Eğer senaryonda soft delete'i bir modify/güncelleme olarak değerlendiriyorsan
            entity.ModifiedDate = DateTime.Now;

            _db.BookTypes.Update(entity);
            _db.SaveChanges();


            return RedirectToAction("List");
        }
    }
}
