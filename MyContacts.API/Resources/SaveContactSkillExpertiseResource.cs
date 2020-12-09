using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Resources
{
    public class SaveContactSkillExpertiseResource
    {
        public int ContactId {get; set;}

        public int ExpertiseId { get; set; }

        public int SkillId { get; set; }
    }
}
