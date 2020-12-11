using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyContacts.Core.Models
{
    /// <summary>
    /// Class used to define the mastering of a skill
    /// It was not asked in the subject but it feels better with it standing alone
    /// </summary>
    public class Expertise
    {
        // ---  Attributes ---
            // -- Public Attributes --
                public int Id { get; set; }

                public string Name { get; set; }

                public ICollection<ContactSkillExpertise> ContactSkillExpertises { get; set; }

                public Expertise()
                {
                    ContactSkillExpertises = new Collection<ContactSkillExpertise>();
                }
    }
}
