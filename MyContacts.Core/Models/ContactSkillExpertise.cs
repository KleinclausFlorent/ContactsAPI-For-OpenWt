using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyContacts.Core.Models
{
    public class ContactSkillExpertise
    {
        public int Id { get; set; }

        [ForeignKey("Expertise")]
        public int ExpertiseId { get; set; }

        public Expertise Expertise { get; set; }

        [ForeignKey("Skill")]
        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}
