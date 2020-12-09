using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Resources
{
    public class ContactSkillExpertiseResource
    {
        public int Id { get; set; }

        public ContactResource Contact { get; set; }

        public ExpertiseResource Expertise { get; set; }

        public SkillResource Skill { get; set; }
    }
}
