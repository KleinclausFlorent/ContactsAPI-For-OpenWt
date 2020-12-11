using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyContactsMVC.ViewModel
{
    /// <summary>
    /// Class used to define the attributes for the Register page 
    /// It allows us to access its attributes in the views and modify it in the controller
    /// </summary>
    public class RegisterViewModel
    {
        // --- Attributes ---
            [Required]
            public string Username { get; set; }

            public SelectList ContactList { get; set; }

            [Required(ErrorMessage = "Please enter the Contact")]
            [Display(Name = "Contact")]
            public int ContactId { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            public bool IsAdmin { get; set; }
    }
}
