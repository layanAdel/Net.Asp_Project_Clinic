using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Clinic_Management_System.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Name is required")]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        [DisplayName("Patient Phone")]
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }

        [DisplayName("Patient Email")]
        public string Email { get; set; }

    }
}
