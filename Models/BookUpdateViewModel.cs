namespace LibraryApp.Models
{
    public class BookUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PageCount { get; set; }
        public int AuthorId { get; set; }
        public int BookTypeId { get; set; }
    }
}
