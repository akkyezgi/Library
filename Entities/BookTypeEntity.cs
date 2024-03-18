namespace LibraryApp.Entities
{
    public class BookTypeEntity : BaseEntity
    {
        public string Name { get; set; }

        // Relational Property

        public List<BookEntity> Books { get; set; }
    }
}
