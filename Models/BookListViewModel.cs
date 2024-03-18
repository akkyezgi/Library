namespace LibraryApp.Models
{
    public class BookListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PageCount { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

        public string AuthorFullName { get { return AuthorFirstName + " " + AuthorLastName; } }
        public string BookType { get; set; }

    }
}
