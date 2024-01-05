/****************************************************************************************
 * @author  : Vishal kumar
 * @file    : Client.c#
 * @purpose : to provide an user interface and communicate with the console
 * **************************************************************************************/
using JuiceShopBusnessLayer;
using JuiceShopEntity;
using JuiceShopException;
using System;
using System.Collections.Generic;

namespace JuiceShopClient
{
    class Client
    {
        static JuiceEntity JuiceObj = new JuiceEntity();
        
        
        static BusnessLayer BusnessObj = new BusnessLayer();
        public static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("*********************************************************************************\n\n" +
                                  "*********************  WELCOME TO OPEN MIND JUICE CENTER  ***********************\n\n" +
                                  "**********************************************************************************\n");
                Console.WriteLine(".......Mark Your choice below......\n  1.To Add the Juice items to the Menu" +
                    "\n  2.To Display Juice Flavours menu\n  3.To Make an order\n  4.Show Orders\n  5.TO Exit...");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        List<JuiceEntity> data = new List<JuiceEntity>(1);
                        Console.WriteLine("Plesse Enter the Details of juice Flavours");
                        int num=BusnessObj.AddFlavour(Inputdata(data));
                        if (num!=0)
                            Console.WriteLine("Item Added sucessfully....!");
                        else
                             JuiceException.InvalidOpration();
                        break;
                    case "2":
                        Printmenu(BusnessObj.DispalyMenu());
                        break;
                    case "3":
                        Console.WriteLine("Choose your flavour id from below");
                        Printmenu(BusnessObj.DispalyMenu());
                        try
                        {
                            int item = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the quantity");
                            int quantity = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(quantity);
                            List<Order> bill = new List<Order>();
                            bill.Add(BusnessObj.CreateOrder(item, quantity));
                            PrintBill(bill);
                        }
                        catch(JuiceException e)
                        {
                            e.InvalidInput();
                        }
                        break;
                    case "4":
                        List<Order> order=BusnessObj.ShowOrder();
                        if (order != null)
                            printOrder(order);
                        break;
                    case "5":
                        Console.WriteLine("......Thank You For Visisting.....");
                        flag = false;
                        break;
                }
            }
        }

       

        private static void PrintBill(List<Order> bill)
        {
            Console.WriteLine("****************************************************\n" +
                              "order Id\tFlavour\tQuantity\tPrice");
            
            foreach(Order orderObj in bill)
            {
                Console.WriteLine(orderObj.Id + "\t\t" + orderObj.Falavour + "\t" + orderObj.Quantity + "\t" + orderObj.Price);
            }
                              
        }

        private static void Printmenu(List<JuiceEntity> data)
        {
            Console.WriteLine("*****************people's juice corner*****************");
            Console.WriteLine("**ItemId\tItem Name\tItem price**");
            foreach(JuiceEntity elements in data)
            {
                Console.WriteLine("**"+elements.JuiceId+"\t\t"+elements.Flavour+"\t\t"+elements.Price+"**");
            }
            Console.WriteLine("*******************************************************");
            
            
        }

        private static List<JuiceEntity> Inputdata(List<JuiceEntity> data)
        {
            try
            {
                Console.WriteLine("Enter the id of the juice :");
                JuiceObj.JuiceId = Convert.ToInt32(Console.ReadLine());                                //try catch here
                Console.WriteLine("Enter the name of the juice flavour :");
                JuiceObj.Flavour = Console.ReadLine();
                Console.WriteLine("Enter the Price of the juice flavour :");
                JuiceObj.Price = Convert.ToInt32(Console.ReadLine());
                data.Add(JuiceObj);

                Console.WriteLine("1. If you want to add more Data to the menu Then press 1\n2. Else press 2");
                if(Console.ReadLine()=="1")
                Inputdata(data);

                return data;

            }catch(JuiceException e)
            {
                e.InvalidInput();
                return null;
            }
        }




        private static void printOrder(List<Order> order)
        {

            Console.WriteLine("####################### Bill Recipt ######################\n" +
                              "Oder ID\tItem\tQuantity\tPrice");
            foreach(Order bill in order)
            {
                Console.WriteLine(bill.Id + "\t" + bill.Falavour + "\t" + bill.Quantity + "\t" + bill.Price);
            }
                     
        }
    }
}
