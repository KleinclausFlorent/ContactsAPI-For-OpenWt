using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Resources
{
    /// <summary>
    /// Class used to define the resource we will display for the contact model
    /// </summary>
    public class ContactResource
    {
        // --- Attributes ---
            public int Id { get; set; }

            public string Firstname { get; set; }

            public string Lastname { get; set; }

            public string Fullname { get; set; }

            public string Adress { get; set; }

            public string Email { get; set; }

    }
}
