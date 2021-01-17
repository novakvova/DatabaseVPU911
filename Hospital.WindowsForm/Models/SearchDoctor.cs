using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.WindowsForm.Models
{
    public class SearchDoctor
    {
        public int ? DepartmentId { get; set; }
        /// <summary>
        /// Ім'я лікаря
        /// </summary>
        public string FirstName { get; set; }
    }
}
