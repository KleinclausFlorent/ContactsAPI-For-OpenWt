using System;

namespace MyContactsMVC.Models
{
    /// <summary>
    /// Class used to define errosrs in the web client context
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
