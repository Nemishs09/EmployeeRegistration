using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistration.Models
{
    public partial class Supervisor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Select Your Salutation")]
        [Display(Name = "Salutation")]
        public string Supervisor_Salutation { get; set; }

        [Required(ErrorMessage = "Enter First Name")]
        [Display(Name = "First Name")]
        public string Supervisor_FirstName { get; set; }

        [Required(ErrorMessage = "Enter Last Name")]
        [Display(Name = "Last Name")]
        public string Supervisor_LastName { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Supervisor_Email { get; set; }

        [Required(ErrorMessage = "Enter Mobile Number")]
        [Display(Name = "Mobile Number")]
        public string Supervisor_Mobile_Number { get; set; }
        public string Supervisor_Department { get; set; }

        [Required(ErrorMessage = "Select Gender")]
        [Display(Name = "Gender")]
        public Enum Supervisor_Gender { get; set; }

        [Required(ErrorMessage = "Select languages")]
        [Display(Name = "Language")]
        public string Supervisor_Language { get; set; }

        [Required(ErrorMessage = "Enter Salary")]
        [Display(Name = "Salary")]
        [Range(1, int.MaxValue)]
        public int Supervisor_Salary { get; set; }
        public DateTime Supervisor_Date_of_Birth { get; set; }
        public int Supervisor_Age { get; set; }
    }
}

