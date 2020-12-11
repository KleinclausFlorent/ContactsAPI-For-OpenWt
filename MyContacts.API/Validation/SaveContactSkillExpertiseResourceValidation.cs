using FluentValidation;
using MyContacts.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Validation
{
    /// <summary>
    /// Class used to make some data validation before sending data to the database 
    /// Fluent Validation makes it easier
    /// ContactSkillExpertise model
    /// </summary>
    public class SaveContactSkillExpertiseResourceValidation : AbstractValidator<SaveContactSkillExpertiseResource>
    {
        // --- Methods ---
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
