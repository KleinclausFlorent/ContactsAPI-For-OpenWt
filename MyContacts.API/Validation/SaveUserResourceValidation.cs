using FluentValidation;
using MyContacts.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Validation
{
    public class SaveUserResourceValidation : AbstractValidator<UserResource>
    {
        public SaveUserResourceValidation()
        {
            RuleFor(m => m.Username)
               .NotEmpty()
               .MaximumLength(50);
            RuleFor(m => m.Password)
               .NotEmpty()
               .MaximumLength(50);

        }
    }
}
