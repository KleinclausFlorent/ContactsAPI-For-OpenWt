using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyContacts.Core.Models
{
    public class Expertise
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ContactSkillExpertise> ContactSkillExpertises { get; set; }

        public Expertise()
        {
            ContactSkillExpertises = new Collection<ContactSkillExpertise>();
        }
    }
}
