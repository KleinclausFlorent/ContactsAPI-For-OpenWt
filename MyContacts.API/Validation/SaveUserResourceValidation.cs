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
    /// User model
    /// </summary>
    public class SaveUserResourceValidation : AbstractValidator<SaveUserResource>
    {
        // --- Methods ---
            public SaveUserResourceValidation()
            {
                RuleFor(u => u.Username)
                   .NotEmpty()
                   .MaximumLength(50);
                RuleFor(u => u.Password)
                   .NotEmpty()
                   .MaximumLength(50);
                RuleFor(u => u.ContactId)
                    .NotEmpty()
                    .WithMessage(" 'Contact Id' must not be 0.");

            }
    }
}
