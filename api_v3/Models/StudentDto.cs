using System.ComponentModel.DataAnnotations.Schema;

namespace api_v3.Models
{
    public class StudentDto
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int AlbumNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PracticePeriod { get; set; }
        public DateTime Term { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public bool Passed { get; set; }

    }
}
