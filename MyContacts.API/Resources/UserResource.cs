using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Resources
{
    /// <summary>
    /// Class used to define the resource we will display for the User model
    /// </summary>
    public class UserResource
    {
        // --- Attributes ---
            public int Id { get; set; }

            public string Username { get; set; }

            public ContactResource Contact { get; set; }

            public string Password { get; set; }

    }
}
