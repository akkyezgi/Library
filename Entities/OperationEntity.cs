namespace LibraryApp.Entities
{
    public class OperationEntity : BaseEntity
    {
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Relational Property

        public StudentEntity Student { get; set; }
        public BookEntity Book { get; set; }
    }
}
