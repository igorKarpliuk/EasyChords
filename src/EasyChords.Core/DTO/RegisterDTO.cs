using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChords.Core.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage ="First name can't be blank")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name can't be blank")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage ="Emaill should be in a proper email address format")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Date of birth can't be blank")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Password can't be blank")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password and confirm password do not match")]
        public string? ConfirmPassword { get; set; }
        public bool KeepSignedIn { get; set; }
    }
}
