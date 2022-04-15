using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem
{
    public class TeacherCourse
    {

       
        [Required]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

       
        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

    }
}
