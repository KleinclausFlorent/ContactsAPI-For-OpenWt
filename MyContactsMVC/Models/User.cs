using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContactsMVC.Models
{
    /// <summary>
    /// Class used to define User in the web client context
    /// </summary>
    public class User
    {
        // --- Attributes ---
            public int Id { get; set; }
            public string Username { get; set; }
        
            public int ContactId { get; set; }
            public string Password { get; set; }
            public bool IsAdmin { get; set; }
    }
}
