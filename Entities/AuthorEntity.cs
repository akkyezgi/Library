namespace LibraryApp.Entities
{
    public class AuthorEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        // Relational Property
        public List<BookEntity> Books { get; set; }

    }
}
