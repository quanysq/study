﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstExample.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    /// <summary>
    /// 学生课程多对多联接
    /// </summary>
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        
        public int CourseID { get; set; }
        
        public int StudentID { get; set; }

        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        
        public virtual Student Student { get; set; }
    }
}