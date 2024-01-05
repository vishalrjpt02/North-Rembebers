/****************************************************************************************
 * @author  : Vishal kumar
 * @file    : BusnesssLayer.c#
 * @purpose : to perform the all logical opration and provide busness layer
 * **************************************************************************************/

using JuiceShopEntity;
using JuiceShopDataAcess;
using System;
using System.Collections.Generic;
using JuiceShopException;

namespace JuiceShopBusnessLayer
{
 
    public class BusnessLayer
    {

       
        private static JuiceDataMannager dataBaseObj = new JuiceDataMannager();

        //adding a new flavour into thejuiceshop menu
        public int AddFlavour(List<JuiceEntity> data )          //data added to flavour
        {
            if (data != null)
            {
                int rows = dataBaseObj.AddToDatabase(data);
                return rows;
            }
            else
            {
                return 0;
            }
        }




        //Displaying the whole juice menu
        public List<JuiceEntity> DispalyMenu()
        {

            List<JuiceEntity> data = dataBaseObj.FindMenu();
            return data;
            
        }



        //adding a oreder entity into the order table
        public Order CreateOrder(int item,int quantity)
        {

            Order  order =dataBaseObj.Placedorder(item,quantity);
            if (order != null)
            {
                return order;
            }
            else
                return null;

        }


        //geeting the whole order from database
        public List<Order> ShowOrder()
        {
            return dataBaseObj.FetchOrders();
        }


        //Updating the data of the juice table
        public int UpdateFlavour(JuiceEntity juice)
        { 
            return JuiceDataMannager.updateJuice(juice);
        }


        //Updating the values to the Order table
        public int UpdateOrder(Order entityOrder)
        {
            return dataBaseObj.OrderUpdate(entityOrder);
        }

        public void RemoveJuice(int id)
        {
            dataBaseObj.DeleteJuice(id);
        }



    }

    
}
