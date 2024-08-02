using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuiceShopEntity
{
    public class Order
    {
        public int Id { get; set; }
        public string Falavour { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}
