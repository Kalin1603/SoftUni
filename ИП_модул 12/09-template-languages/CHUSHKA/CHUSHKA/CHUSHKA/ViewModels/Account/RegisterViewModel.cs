using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.ViewModels.Account
{
    public class RegisterViewModel
    {   
        
        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(100,ErrorMessage = "The {0} must be a least {2} and at max {1} characters long. ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]   
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [Compare("Password",ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="FullName")]
        public string FullName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email { get; set; }
    }
}
