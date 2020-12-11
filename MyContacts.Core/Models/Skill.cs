using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyContacts.Core.Models
{
    /// <summary>
    /// Class used to define the skill
    /// </summary>
    public class Skill
    {
        // ---  Attributes ---
            // -- Public Attributes --
                public int Id { get; set; }

                public string Name { get; set; }

                public ICollection<ContactSkillExpertise> ContactSkillExpertises { get; set; }

                public Skill()
                {
                    ContactSkillExpertises = new Collection<ContactSkillExpertise>();
                }


    }
}
