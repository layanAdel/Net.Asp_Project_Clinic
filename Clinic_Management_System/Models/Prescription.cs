using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Clinic_Management_System.Models
{
    public class Prescription
    {
        public int Id { get; set; }

        [DisplayName("Patient First Name")]
        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; }

        [DisplayName("Patient Last Name")]
        [Required(ErrorMessage = "Name is required")]
        public string LastName { get; set; }

        [DisplayName("Doctor First Name")]
        [Required(ErrorMessage = "Name is required")]
        public string DoctorFirstName { get; set; }

        [DisplayName("Doctor Last Name")]
        [Required(ErrorMessage = "Name is required")]
        public string DoctorLastName { get; set; }

        [Required(ErrorMessage = "Medication is required")]
        public string Medication { get; set; }

        [Required(ErrorMessage = "Dosage is required")]
        public string Dosage { get; set; }

        public string Instructions { get; set; }

        [Required(ErrorMessage = "PrescriptionDate is required")]
        public DateTime PrescriptionDate { get; set; }
    }
}
