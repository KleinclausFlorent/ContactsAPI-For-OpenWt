using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyContactsMVC.ViewModel
{
    /// <summary>
    /// Class used to define the attributes for the login page 
    /// It allows us to access its attributes in the views and modify it in the controller
    /// </summary>
    public class LoginViewModel
    {
        // --- Attributes ---
            [Required]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
    }
}
