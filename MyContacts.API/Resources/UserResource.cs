using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Resources
{
    public class UserResource
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public ContactResource Contact { get; set; }

        public string Password { get; set; }

        public bool isAdmin { get; set; }
    }
}
