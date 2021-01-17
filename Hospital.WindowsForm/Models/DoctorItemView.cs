using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.WindowsForm.Models
{
    public class DoctorItemView
    {
        public int Id { get; set; }
        /// <summary>
        /// Повне ім'я (прізвище + ім'я) хворого
        /// </summary>
        public string Name { get; set; }
        public int Stage { get; set; }
        public string Department { get; set; }
    }
}
