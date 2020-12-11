using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContactsMVC.Models
{

    /// <summary>
    /// Class used to define ContactSkillExpertise in the web client context
    /// </summary>
    public class ContactSkillExpertise
    {
        // --- Attributes ---
            public int Id { get; set; }

            public int ExpertiseId { get; set; }

            public Expertise Expertise { get; set; }

            public int SkillId { get; set; }

            public Skill Skill { get; set; }

            public int ContactId { get; set; }

            public Contact Contact { get; set; }

    }
}
