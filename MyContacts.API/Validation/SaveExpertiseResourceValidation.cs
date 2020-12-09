using FluentValidation;
using MyContacts.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Validation
{
    public class SaveExpertiseResourceValidation : AbstractValidator<SaveExpertiseResource>
    {
        public SaveExpertiseResourceValidation()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
