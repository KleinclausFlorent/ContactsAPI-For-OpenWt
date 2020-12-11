using Microsoft.AspNetCore.Mvc.Rendering;
using MyContactsMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyContactsMVC.ViewModel
{
    /// <summary>
    /// Class used to make another definition of ContactSkillExpertise in the web client context
    /// It allows us to access its attributes in the views and modify it in the controller
    /// </summary>
    public class ContactSkillExpertiseViewModel
    {
        // --- Attributes ---
            public string CSEId { get; set; }

            public SelectList ContactList { get; set; }

            [Required(ErrorMessage = "Please enter the Contact")]
            [Display(Name = "Contact")]
            public string ContactId { get; set; }

            public SelectList SkillList { get; set; }
            [Required(ErrorMessage = "Please enter the skill")]
            [Display(Name = "Skill")]
            public string SkillId { get; set; }

            public SelectList ExpertiseList { get; set; }
            [Required(ErrorMessage = "Please enter the Expertise")]
            [Display(Name = "Expertise")]
            public string ExpertiseId { get; set; }
    }
}
