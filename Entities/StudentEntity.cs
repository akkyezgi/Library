namespace LibraryApp.Entities
{
    public class StudentEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string SchoolNumber { get; set; }
        public DateTime BirthDate { get; set; }

        // Relational Property

        public List<OperationEntity> Operations { get; set; }
    }
}
