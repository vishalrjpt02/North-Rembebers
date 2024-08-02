using CCD_DataAccessLayer.DAL_Layer;
using CCD_EnitityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD_BusinessAccessLayer.CCD_BusinessAccessLayer
{
    public class BusinessAccessLayer 
    {
        public BusinessAccessLayer() 
        { 

        }
        private readonly IDataAccessLayer _customerDAL;
        public BusinessAccessLayer(IDataAccessLayer dataAccessLayer)
        {
            _customerDAL = dataAccessLayer;

        }

        public Customer AddNewCustomer(Customer _customer)
        {
            return _customerDAL.AddNewCustomer(_customer);
        }
        public Product AddNewProduct(Product _product)
        {
            return _customerDAL.AddNewProduct(_product);
        }
        public Order AddNewOrder(Order _order)
        {
            List<Product> products = _customerDAL.SearchProduct();
            Product product = new Product();
            product.ID = _order.productID;
            foreach (Product p in products)
            {
                if(p.ID == _order.productID)
                {
                    _order.price = (decimal)((_order.quantity) * p.Price);
                }
            }
            return _customerDAL.AddNewOrder(_order);
        }
        public List<Customer> SearchCustomer()
        {
            return _customerDAL.SearchCustomer();
        }
        public List<Product> SearchProduct()
        {
            return _customerDAL.SearchProduct();
        }
        public List<Order> SearchOrder()
        {
            return _customerDAL.SearchOrder();
        }

        public Customer SearchByCustomerId(int id)
        {
            List<Customer> customers = _customerDAL.SearchCustomer();
          
            foreach (Customer c in customers)
            {
                if (c.CustID == id)
                {
                    return c;
                }
            }
            return null;
        }
        public Order SearchByOrderId(int id)
        {
            List<Order> Orders = _customerDAL.SearchOrder();

            foreach (Order o in Orders)
            {
                if (o.orderID == id)
                {
                    return o;
                }
            }
            return null;
        }
        public Product SearchByProductId(int id)
        {
            List<Product> products = _customerDAL.SearchProduct();

            foreach (Product p in products)
            {
                if (p.ID == id)
                {
                    return p;
                }
            }
            return null;
        }
         
    }
}
