using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_file_reader
{
    public  class FileReading
    {
        public static void Main(string[] args)
        {
            //StreamReader reader = new StreamReader("C:\\Users\visha\Desktop\Demotext.txt");
            var line = "sanjay yadav : 28, bugsou jhjdhfisd : 34, ijbiuhcwniucwe : 12";
            string path = @"C:\\Users\\visha\\Desktop\\Demotext.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    //StreamWriter writer = new StreamWriter(@"C:\Users\visha\Desktop\Demotext.txt");
                    File.AppendAllText(@"C:\Users\visha\Desktop\Demotext.txt", line);
                    
                }
                
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    File.AppendAllText(@"C:\Users\visha\Desktop\Demotext.txt", line);
                }
            }
            
            var filedata =File.ReadAllLines(path);
            foreach(string data in filedata)
            {
                Console.WriteLine(line);
            }
           
            
            
        }
    }
}
