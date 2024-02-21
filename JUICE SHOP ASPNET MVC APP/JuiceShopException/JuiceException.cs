using System;
using System.Data.SqlClient;

namespace JuiceShopException
{
    public class JuiceException : Exception
    {
        // Exception e = new Exception();
        //public bool itemNotFound;

        public JuiceException() : base()
        {
            Console.WriteLine("Invalid opration");
        }

        public JuiceException(String message) : base()
        {
            Console.WriteLine(message);
        }

        public void Oprationfail()
        {
            Console.WriteLine("Opration falied try again..");
        }

        public void InvalidInput()
        {
            Console.WriteLine("Sorry Inavalid input...");
        }
        public void ItemNotfound()
        {
            Console.WriteLine("Sorry item you requested not found");
        }

        public static void InvalidOpration()
        {
            Console.WriteLine("Invalid Opration");
        }
    }
    
    public class ExceptionInSql :Exception
    {
        public ExceptionInSql (SqlException e):base("Inavalid Id")
        {
            Console.WriteLine(e.Message);
        }

    }
       
}
