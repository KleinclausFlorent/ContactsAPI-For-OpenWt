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
    /// Contact model
    /// </summary>
    public class SaveContactResourceValidation : AbstractValidator<SaveContactResource>
    {
        // --- Methods ---
            public SaveContactResourceValidation()
            {
                RuleFor(c => c.Firstname)
                    .NotEmpty()
                    .MaximumLength(50);
                RuleFor(c => c.Lastname)
                    .NotEmpty()
                    .MaximumLength(50);
                RuleFor(c => c.Fullname)
                    .NotEmpty()
                    .MaximumLength(200);
                RuleFor(c => c.Email)
                    .NotEmpty()
                    .MaximumLength(200);
               RuleFor(c => c.Adress)
                    .NotEmpty()
                    .MaximumLength(200);
                RuleFor(c => c.Mobile)
                    .NotEmpty()
                    .MaximumLength(20);
            }
    }
}
