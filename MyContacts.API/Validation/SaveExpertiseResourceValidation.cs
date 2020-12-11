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
    /// Expertise model
    /// </summary>
    public class SaveExpertiseResourceValidation : AbstractValidator<SaveExpertiseResource>
    {
        // --- Methods ---
            public SaveExpertiseResourceValidation()
            {
                RuleFor(e => e.Name)
                    .NotEmpty()
                    .MaximumLength(50);
            }
    }
}
