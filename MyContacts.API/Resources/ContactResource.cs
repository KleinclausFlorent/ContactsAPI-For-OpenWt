using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Resources
{
    public class ContactResource
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Fullname { get; set; }

        public string Adress { get; set; }

        public string Email { get; set; }

    }
}
