using Microsoft.AspNetCore.Mvc.Rendering;
using MyContactsMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyContactsMVC.ViewModel
{
    public class ContactSkillExpertiseViewModel
    {
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
