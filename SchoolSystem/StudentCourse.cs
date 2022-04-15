using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem
{
    
    public class StudentCourse
    {
 

        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public Status Status { get; set; }
       
        public double Assessment { get; set; }

    }
}
