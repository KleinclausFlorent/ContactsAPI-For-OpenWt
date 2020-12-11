using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyContacts.Core.Models
{
    /// <summary>
    /// class used to define the user 
    /// with a link to a contact to handle authorizations and a password and username for the authentification
    /// </summary>
    public class User
    {
        // ---  Attributes ---
            // -- Public Attributes --
                public int Id { get; set; }

                public string Username { get; set; }

                [ForeignKey("Contact")]
                public int ContactId { get; set; }

                public virtual Contact Contact { get; set; }

                public byte[] PasswordHash { get; set; }
                public byte[] PasswordSalt { get; set; }

                ///<remarks>
                ///This bool is not used but we could make a super user later
                /// </remarks>
                public bool isAdmin { get; set; }

        
    }
}
