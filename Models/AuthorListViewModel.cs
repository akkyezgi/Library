namespace LibraryApp.Models
{
    public class AuthorListViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName {
            get
            {
                return FirstName + " " + LastName;
            }        
        }

        // Gerektiğinde firstname ve lastname i ayrı ayrı çekmektense fullname olarak tek seferde diğer propertylerini referans alarak çekebilirim.


    }
}
