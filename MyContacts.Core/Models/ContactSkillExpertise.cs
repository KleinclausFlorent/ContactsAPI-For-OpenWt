using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyContacts.Core.Models
{
    /// <summary>
    /// Class used to define the object that represents the table between Contact, Skill and Expertise.
    /// It allows us to define our associations
    /// </summary>
    public class ContactSkillExpertise
    {
        // ---  Attributes ---
            // -- Public Attributes --
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
