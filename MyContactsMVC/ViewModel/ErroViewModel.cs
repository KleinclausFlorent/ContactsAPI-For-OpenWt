using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContactsMVC.ViewModel
{
    public class ErroViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
