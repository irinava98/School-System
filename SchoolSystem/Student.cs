using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem
{
    public class Student: IIdentifiable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FristName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

       
    }
}
