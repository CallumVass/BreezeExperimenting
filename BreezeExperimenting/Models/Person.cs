using System.ComponentModel.DataAnnotations;

namespace BreezeExperimenting.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(35)]
        public string FirstName { get; set; }
        [Required, MaxLength(35)]
        public string LastName { get; set; }
        [Required, MaxLength(100)]
        public string Location { get; set; }
        [Required]
        public int Age { get; set; }
    }
}