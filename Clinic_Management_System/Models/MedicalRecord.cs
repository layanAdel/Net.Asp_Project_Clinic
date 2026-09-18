using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Clinic_Management_System.Models
{
    public class MedicalRecord
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

        [DisplayName("Visit Date")]
        [Required(ErrorMessage = "Visit Date is required")]
        public DateTime VisitDate { get; set; }

        [Required(ErrorMessage = "Diagnosis is required")]
        public string Diagnosis { get; set; }

        [DisplayName("Doctor Notes")]
        public string Notes { get; set; }
    }
}
