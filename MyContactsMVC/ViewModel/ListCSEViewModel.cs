using MyContactsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContactsMVC.ViewModel
{
    /// <summary>
    /// Class used to make another definition of a list of ContactSkillExpertise in the web client context
    /// It allows us to access its attributes in the views and modify it in the controller
    /// </summary>
    public class ListCSEViewModel
    {
        // --- Attributes ---
            public List<ContactSkillExpertise> ListCSE;
    }
}
