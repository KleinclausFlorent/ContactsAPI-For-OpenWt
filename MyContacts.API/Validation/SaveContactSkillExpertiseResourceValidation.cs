using FluentValidation;
using MyContacts.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Validation
{
    public class SaveContactSkillExpertiseResourceValidation : AbstractValidator<SaveContactSkillExpertiseResource>
    {
        public SaveContactSkillExpertiseResourceValidation()
        {
            RuleFor(x => x.ContactId)
                .NotEmpty()
                .WithMessage(" 'Contact Id' must not be 0.");
            RuleFor(x => x.SkillId)
                .NotEmpty()
                .WithMessage(" 'Skill Id' must not be 0.");
            RuleFor(x => x.ExpertiseId)
                .NotEmpty()
                .WithMessage(" 'Expertise Id' must not be 0.");
        }
    }
}
