using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Resources
{
    public class SaveUserResource
    {
        public string Username { get; set; }

        public int ContactId { get; set; }

        public string Password { get; set; }

    }
}
