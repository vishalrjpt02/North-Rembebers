using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD_EnitityLayer
{
    [Table("tblProduct")]
    public class Product
    {
        [Key]
        public int ID { get; set; }  
        
        [Column(TypeName = "nvarchar(100)")]
        public string ProductName { get; set; }

        [Column(TypeName ="decimal")]
        public float Price { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

    }
}
