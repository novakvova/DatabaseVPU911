﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.DAL
{
    [Table("tblDoctors")]
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public int Stage { get; set; }
        public virtual Department Department { get; set; }
    }
}
