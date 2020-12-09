using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContactsMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        
        public int ContactId { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
