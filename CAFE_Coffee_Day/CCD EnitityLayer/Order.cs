using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD_EnitityLayer
{
    [Table("tblOrder")]
    public class Order
    {

        
        [Key]
        public int orderID { get; set; }

        [Column(TypeName = "int")]
        public int quantity { get; set; }

        [Column(TypeName = "decimal")]
        public decimal price { get; set; }

        [ForeignKey("product")]
        public int productID { get; set; }

        [ForeignKey("customer")]
        public int customerId { get; set; }


        public virtual Product product { get; set; }      
        public virtual Customer customer { get; set; }

    }
}
