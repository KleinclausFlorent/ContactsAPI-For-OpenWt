using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Resources
{
    /// <summary>
    /// Class used to define the resource we will ask for the User model
    /// </summary>
    public class SaveUserResource
    {
        // --- Attributes ---
            public string Username { get; set; }

            public int ContactId { get; set; }

            public string Password { get; set; }

    }
}
