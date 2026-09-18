using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Clinic_Management_System.Models
{
    public class Department
    {
        public int Id { get; set; }

        [DisplayName("Department Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
