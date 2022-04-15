using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem
{
    public class Studentinformation: IIdentifiable
    {
        [Key]
        [ForeignKey("Student")]
        public int Id { get; set; } 

        public DateTime CreationDate { get; set; }

       

    }
}
