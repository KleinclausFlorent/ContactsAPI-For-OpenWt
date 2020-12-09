using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyContacts.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public bool isAdmin { get; set; }

        
    }
}
