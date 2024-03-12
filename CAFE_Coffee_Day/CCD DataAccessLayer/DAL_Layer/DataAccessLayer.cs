using CCD_DataAccessLayer.CCD_DbContext;
using CCD_EnitityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD_DataAccessLayer.DAL_Layer
{
    public class DataAccessLayer : IDataAccessLayer
    {
        CCD_InvoiceContext _ccdDbContext;
        public DataAccessLayer(CCD_InvoiceContext dbContext)
        {
            _ccdDbContext = dbContext;
        }

        public Customer AddNewCustomer(Customer _customer)
        {
            var customer = _ccdDbContext.Customers.Add(_customer);
            _ccdDbContext.SaveChanges();
            return customer.Entity;
        }

        public Order AddNewOrder(Order _order)
        {
            var order = _ccdDbContext.Orders.Add(_order);
            _ccdDbContext.SaveChanges();
            return order.Entity;
        }

        public Product AddNewProduct(Product _product)
        {
            try
            {
                var product = _ccdDbContext.Products.Add(_product);
                _ccdDbContext.SaveChanges();
                return product.Entity;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public List<Customer> SearchCustomer()
        {
            try
            {
                List<Customer> _customers = _ccdDbContext.Customers.ToList();
                if (_customers != null)
                {
                    return _customers;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Order> SearchOrder()
        {
            try
            {
                List<Order> _order = _ccdDbContext.Orders.ToList();
                if (_order != null)
                {
                    return _order;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Product> SearchProduct()
        {
            try
            {
                List<Product> _product = _ccdDbContext.Products.ToList();
                if (_product != null)
                {
                    return _product;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
