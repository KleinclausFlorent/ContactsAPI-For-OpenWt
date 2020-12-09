using FluentValidation;
using MyContacts.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Validation
{
    public class SaveSkillResourceValidation : AbstractValidator<SaveSkillResource>
    {

        public SaveSkillResourceValidation()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
