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
    /// Skill model
    /// </summary>
    public class SaveSkillResourceValidation : AbstractValidator<SaveSkillResource>
    {
        // --- Methods ---
            public SaveSkillResourceValidation()
            {
                RuleFor(s => s.Name)
                    .NotEmpty()
                    .MaximumLength(50);
            }
    }
}
