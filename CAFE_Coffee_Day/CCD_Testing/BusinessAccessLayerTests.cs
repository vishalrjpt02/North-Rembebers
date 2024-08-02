using CCD_BusinessAccessLayer.CCD_BusinessAccessLayer;
using CCD_DataAccessLayer.DAL_Layer;
using CCD_EnitityLayer;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CCD_BusinessAccessLayer.Test
{
    [TestClass]
    public class BusinessAccessLayerTests
    {
        private readonly BusinessAccessLayer _businessAccessLayer  = new BusinessAccessLayer();
       

       

        [TestMethod]
        public void AddNewCustomer_ValidCustomer_ReturnsCustomer()
        {
            // Arrange
            Customer customerToAdd = new Customer
            {
                CustID = 1, // Example customer ID
                Name = "John Doe", // Example customer name
                Email = "john.doe@example.com" // Example customer email
                // Add more properties as needed
            };

            // Act
            Customer addedCustomer = _businessAccessLayer.AddNewCustomer(customerToAdd);

            // Assert
            Assert.IsNotNull(addedCustomer);
            Assert.AreEqual(customerToAdd.CustID, addedCustomer.CustID);
            Assert.AreEqual(customerToAdd.Name, addedCustomer.Name);
            Assert.AreEqual(customerToAdd.Email, addedCustomer.Email);
        }

        [TestMethod]
        public void AddNewProduct_ValidProduct_ReturnsProduct()
        {
            // Arrange
            Product productToAdd = new Product
            {
                ID = 1, // Example product ID
                ProductName = "Espresso", // Example product name
                Price = 2.50f // Example product price
                // Add more properties as needed
            };

            // Act
            Product addedProduct = _businessAccessLayer.AddNewProduct(productToAdd);

            // Assert
            Assert.IsNotNull(addedProduct);
            Assert.AreEqual(productToAdd.ID, addedProduct.ID);
            Assert.AreEqual(productToAdd.ProductName, addedProduct.ProductName);
            Assert.AreEqual(productToAdd.Price, addedProduct.Price);
        }

        [TestMethod]
        public void AddNewOrder_ValidOrder_ReturnsOrder()
        {
            // Arrange
            Order orderToAdd = new Order
            {
                orderID = 1, // Example order ID
                productID = 1, // Example product ID
                quantity = 2 // Example quantity
                // Add more properties as needed
            };

            // Act
            Order addedOrder = _businessAccessLayer.AddNewOrder(orderToAdd);

            // Assert
            Assert.IsNotNull(addedOrder);
            Assert.AreEqual(orderToAdd.orderID, addedOrder.orderID);
            Assert.AreEqual(orderToAdd.productID, addedOrder.productID);
            Assert.AreEqual(orderToAdd.quantity, addedOrder.quantity);
            // Add more assertions if needed based on the expected behavior of AddNewOrder method.
        }

        [TestMethod]
        public void SearchCustomer_ReturnsListOfCustomers()
        {
            // Act
            List<Customer> customers = _businessAccessLayer.SearchCustomer();

            // Assert
            Assert.IsNotNull(customers);
            // Add assertions to verify the returned list of customers.
        }

        [TestMethod]
        public void SearchProduct_ReturnsListOfProducts()
        {
            // Act
            List<Product> products = _businessAccessLayer.SearchProduct();

            // Assert
            Assert.IsNotNull(products);
            // Add assertions to verify the returned list of products.
        }

        [TestMethod]
        public void SearchOrder_ReturnsListOfOrders()
        {
            // Act
            List<Order> orders = _businessAccessLayer.SearchOrder();

            // Assert
            Assert.IsNotNull(orders);
            // Add assertions to verify the returned list of orders.
        }

        [TestMethod]
        public void SearchByCustomerId_ValidId_ReturnsCustomer()
        {
            // Arrange
            int customerIdToSearch = 1; // Example customer ID to search

            // Act
            Customer foundCustomer = _businessAccessLayer.SearchByCustomerId(customerIdToSearch);

            // Assert
            Assert.IsNotNull(foundCustomer);
            Assert.AreEqual(customerIdToSearch, foundCustomer.CustID);
            // Add more assertions if needed based on the expected behavior of SearchByCustomerId method.
        }

        [TestMethod]
        public void SearchByOrderId_ValidId_ReturnsOrder()
        {
            // Arrange
            int orderIdToSearch = 1; // Example order ID to search

            // Act
            Order foundOrder = _businessAccessLayer.SearchByOrderId(orderIdToSearch);

            // Assert
            Assert.IsNotNull(foundOrder);
            Assert.AreEqual(orderIdToSearch, foundOrder.orderID);
            // Add more assertions if needed based on the expected behavior of SearchByOrderId method.
        }

        [TestMethod]
        public void SearchByProductId_ValidId_ReturnsProduct()
        {
            // Arrange
            int productIdToSearch = 1; // Example product ID to search

            // Act
            Product foundProduct = _businessAccessLayer.SearchByProductId(productIdToSearch);

            // Assert
            Assert.IsNotNull(foundProduct);
            Assert.AreEqual(productIdToSearch, foundProduct.ID);
            // Add more assertions if needed based on the expected behavior of SearchByProductId method.
        }
    }
}
