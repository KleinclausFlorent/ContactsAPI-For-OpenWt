using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Resources
{
    /// <summary>
    /// Class used to define the resource we will ask for the ContactSkillExpertise model
    /// </summary>
    public class SaveContactSkillExpertiseResource
    {
        // --- Attributes ---
            public int ContactId {get; set;}

            public int ExpertiseId { get; set; }

            public int SkillId { get; set; }
    }
}
