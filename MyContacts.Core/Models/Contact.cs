﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyContacts.Core.Models
{
    /// <summary>
    /// Class used to define the contact object with its attributes
    /// </summary>
    public class Contact
    {
        // ---  Attributes ---
            // -- Public Attributes --
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Fullname { get; set; }

        public string Adress { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public virtual User User { get; set; }

        public ICollection<ContactSkillExpertise> ContactSkillExpertises { get; set; }

        public Contact()
        {
            ContactSkillExpertises = new Collection<ContactSkillExpertise>();
        }

    }
}
