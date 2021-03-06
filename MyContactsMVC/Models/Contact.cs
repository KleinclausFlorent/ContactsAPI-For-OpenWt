﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContactsMVC.Models
{
    /// <summary>
    /// Class used to define contact in the web client context
    /// </summary>
    public class Contact
    {
        // --- Attributes ---
            public int Id { get; set; }

            public string Firstname { get; set; }

            public string Lastname { get; set; }

            public string Fullname { get; set; }

            public string Adress { get; set; }

            public string Email { get; set; }

            public string Mobile { get; set; }
    }
}
