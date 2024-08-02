using CCD_EnitityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD_DataAccessLayer.DAL_Layer
{
    public interface IDataAccessLayer
    {
        public Customer AddNewCustomer(Customer _customer);
        public Product AddNewProduct(Product _product);
        public Order AddNewOrder(Order _order);
        public List<Customer> SearchCustomer();
        public List<Product> SearchProduct();
        public List<Order> SearchOrder();
        



    }
}
