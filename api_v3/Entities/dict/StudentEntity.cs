namespace api_v3.Entities.dict
{
    public class StudentEntity : BaseModifiableEntity
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
