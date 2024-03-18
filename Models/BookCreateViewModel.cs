namespace LibraryApp.Models
{
    public class BookCreateViewModel
    {
        public string Name { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public int BookTypeId { get; set; }
    }
}
