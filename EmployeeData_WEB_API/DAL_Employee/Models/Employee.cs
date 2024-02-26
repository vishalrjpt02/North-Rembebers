using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Employee.Models
{
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string EmpName { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string EmpCode { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(13)")]
        public string Phone { get; set; }

    }
}
