using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Resources
{
    /// <summary>
    /// Class used to define the resource we will display for the contactSkillExpertise model
    /// </summary>
    public class ContactSkillExpertiseResource
    {
        // --- Attributes ---
            public int Id { get; set; }

            public ContactResource Contact { get; set; }

            public ExpertiseResource Expertise { get; set; }

            public SkillResource Skill { get; set; }
    }
}
