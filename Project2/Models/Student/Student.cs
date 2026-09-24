using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [StringLength(20,MinimumLength =3,ErrorMessage ="Name should be between 3 to 20")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Address is Required")]
        [StringLength(50,MinimumLength =5,ErrorMessage ="Student Adress mus be between 5 to 50")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Age is Required")]
        [Range(5,20,ErrorMessage ="Age must be between 5 to 20")]
        public int Age { get; set; }
        [Required(ErrorMessage ="Email Address is Required")]
        [EmailAddress(ErrorMessage ="Please Enter a Valid Email Address")]
        public string? Email { get; set; }
    }
}
