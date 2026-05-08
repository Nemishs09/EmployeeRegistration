using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistration.Models
{
    public partial class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Select Your Salutation")]
        [Display(Name = "Salutation")]
        public string Salutation { get; set; }

        [Required(ErrorMessage = "Enter First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Mobile Number")]
        [Display(Name = "Mobile Number")]
        public string Mobile_Number { get; set; }
        public string Department { get; set; }

        [Required(ErrorMessage = "Select Gender")]
        [Display(Name = "Gender")]
        public Enum Gender { get; set; }

        [Required(ErrorMessage = "Select languages")]
        [Display(Name = "Language")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Enter Salary")]
        [Display(Name = "Salary")]
        [Range(1, int.MaxValue)]
        public int? Salary { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public int? Age { get; set; }
    }
}
