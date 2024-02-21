/*************************************************************************************************
 * @author  : Vishal kumar
 * @file    : JuiceDatamanager.c#
 * @purpose : to add and retrive data from database i.e: ado.net and stored procedure will be used
 * **********************************************************************************************/

using JuiceShopEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace JuiceShopDataAcess
{
    public class JuiceDataMannager
    {
        


        /*method to add data to the flavour table
        * @param list<> 
        * @return number of row that are added
        */
        public int AddToDatabase(List<JuiceEntity> data)     
        {
            int num = 0;
            foreach (JuiceEntity juices in data)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"data source=.; database=mindtree;integrated security=SSPI";
                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = $"insert into juiceshop values(@flavour,@price)";
                cmd.Connection = con;
               
                cmd.Parameters.AddWithValue("@flavour", juices.Flavour);
                cmd.Parameters.AddWithValue("@price", juices.Price);

                SqlTransaction Transect = null;
                try
                {
                    con.Open();
                    Transect = con.BeginTransaction();
                    cmd.Transaction = Transect;
                    num = cmd.ExecuteNonQuery();
                    if (num != 0)
                    {
                        Transect.Commit();
                    }
                    else
                    {
                        Transect.Rollback();
                    }
                    return num;
                }
                catch(SqlException e)
                {
                    throw new JuiceException("Invalid input >>>",e);
                    
                }
                catch(JuiceException e)
                {
                    Transect.Rollback();
                    Console.WriteLine(e.Message);
                    return 0;
                }
            }
            return num;
        }
        


        /*Method to update the data inside of order table
         * @param object of Order type
         * @return total number of row changes
         */
        public int OrderUpdate(Order order)
        {
            SqlConnection con = new SqlConnection(@"data source=.;database=mindtree;integrated security=SSPI");
            int rowchanged = 0;
            using (con)
            {
                con.Open();
                DataTable table = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter($"select * from juiceshop where juice id=@id", con);
                sda.SelectCommand.Parameters.AddWithValue("@id", order.Id);
                sda.Fill(table);
                int unitprice = (int)table.Rows[0][2];
            

                SqlCommand cmd = new SqlCommand($"update JuiceOrder set Flavour=@flavour,quantity=@quantity,price=@price where orderid=@id", con);
                cmd.Parameters.AddWithValue("@flavour", order.Falavour);
                cmd.Parameters.AddWithValue("@quantity", order.Quantity);
                cmd.Parameters.AddWithValue("@price", order.Price*unitprice);
                cmd.Parameters.AddWithValue("@flavour", order);
                rowchanged=cmd.ExecuteNonQuery();
            }
            return rowchanged;
        }

        

        /* Method to update the juice table in dataBase
         * @param juiceEntity Object
         * @return JuiceEntity Object
         */
        public static int updateJuice(JuiceEntity juice)
        {
            SqlConnection con = new SqlConnection(@"data source=.;database=mindtree;integrated security=SSPI");
            SqlCommand UpdateCmd = new SqlCommand($"update JuiceShop set flavour=@flav,price=@price where id = @id", con);
            int num = 0;
            try
            {
                using (con)
                {
                    con.Open();
                    UpdateCmd.Parameters.AddWithValue("@flav", juice.Flavour);
                    UpdateCmd.Parameters.AddWithValue("@price", juice.Price);
                    UpdateCmd.Parameters.AddWithValue("@id", juice.JuiceId);
                    num = UpdateCmd.ExecuteNonQuery();
                }
                return num;


            }
            catch (Exception e)
            {
                return 0;
            }
            
        }



        /* Method to read data from flavours table
         * @param void
         * @return list<> of object of juice Entity class
         */
        public List<JuiceEntity> FindMenu()                  
        {
            List<JuiceEntity> menu = new List<JuiceEntity>(2);
            SqlConnection con = new SqlConnection(@"data source=.; database=mindtree;integrated security=SSPI");
            SqlCommand cmd = new SqlCommand($"select *from juiceshop ", con);
            try
            {
                con.Open();
                var table= cmd.ExecuteReader();
                while (table.Read())
                {
                    JuiceEntity data=new JuiceEntity();
                    data.JuiceId = (int)table["id"];
                    data.Flavour = table["flavour"].ToString();
                    data.Price = (int)table["price"];
                    menu.Add(data);
                }
                return menu;
            }
            catch(JuiceException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        /*Method to search a flavour and create an order
         * @param item id,quantity
         * @return list<> of object of order class 
         */
        public Order Placedorder(int item,int quantity)
        {
            Order bill = new Order();
            SqlConnection con = new SqlConnection(@"data source=.; database=mindtree;integrated security=SSPI");
            List<Order> order = new List<Order>();
            try
            {
                using (con)
                {
                    con.Open();
                    DataTable juicetable = new DataTable();
                    string querry=$"select *from juiceshop where id = @id";
                    SqlDataAdapter sda = new SqlDataAdapter(querry, con);
                    sda.SelectCommand.Parameters.AddWithValue("@id",item);
                    sda.Fill(juicetable);
                    
                   
                    //finding the juice contents
                    bill.Falavour = juicetable.Rows[0][1].ToString();
                    bill.Price = Convert.ToInt32(juicetable.Rows[0][2].ToString())*quantity;
                    bill.Quantity = quantity;
                    


                    //con.Close();

                    //inserting order details into the oreder table of database

                    SqlCommand ordercmd = new SqlCommand($"insert into juiceorder values(@flavour,@quantity,@price,@id)",con);
                    ordercmd.Parameters.AddWithValue("@flavour", bill.Falavour);
                    ordercmd.Parameters.AddWithValue("@quantity", bill.Quantity);
                    ordercmd.Parameters.AddWithValue("@price", bill.Price);
                    ordercmd.Parameters.AddWithValue("@id", item);
                    
                    int num = ordercmd.ExecuteNonQuery();
                    con.Close();


                }
                return bill;
            }
            catch(JuiceException e)
            {
                
                return null;
            }
            
        }


        /*Method to fetch all orders and display them
         * @param void
         * @return list of order object type
         */
        public List<Order> FetchOrders()
        {
            
            List<Order> orders = new List<Order>();
            SqlConnection con = new SqlConnection(@"data source=.;database=mindtree;integrated security=SSPI");
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("select *from JuiceOrder",con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Order bill = new Order
                        {
                            Id = (int)sdr["orderId"],
                            Falavour = sdr["flavour"].ToString(),
                            Quantity = (int)sdr["quantity"],
                            Price = (int)sdr["price"]
                        };
                        orders.Add(bill);
                    }

                    return orders;
                }
            }
            catch(JuiceException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }


        /*Method to Delete a juice flavour from list
        * @param void
        * @return void
        */

        public void DeleteJuice(int id)
        {
            SqlConnection con = new SqlConnection(@"data source=.;database=mindtree;integrated security=SSPI");
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Delete from JuiceShop where id=@id",con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(JuiceException e)
            {
                throw new JuiceException("invalid opration",e);
            }

        }

    }
}
