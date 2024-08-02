using System;
using System.Collections;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

class FileReading
{
    static void Main(string[] args)
    {
        string _file = @"C:\Users\visha\Documents\Student.txt";
        string _fileData = "\n Helllo this is vishal kumar       ";

        ArrayList data = new ArrayList{ 12, 34, 56, 7, 8, 35, 65, 4 ,4,4,4,};
        removeDups(data);

        Console.WriteLine("Reading File using File.ReadAllText()");


        if (File.Exists(_file))
        {
            string str = File.ReadAllText(_file);
            
            File.AppendAllText( _file,_fileData);
            //File.AppendAllText(removeDups(data).ToString(), _file);

            //Console.WriteLine(str);
        }
        else
        {
            File.Create(_file);
            File.AppendAllText(_fileData, _file);
        }
        Console.WriteLine();

        Console.WriteLine("Reading File using File.ReadAllLines()");

        if (File.Exists(_file))
        {
            string[] lines = File.ReadAllLines(_file);

            //foreach (string ln in lines)
                //Console.WriteLine(ln);
        }
        Console.WriteLine();

        //Console.WriteLine("Reading File using StreamReader");

        // By using StreamReader 
        if (File.Exists(_file))
        {

            StreamReader Textfile = new StreamReader(_file);
            string line;
            //var myArray = new System.Collections.ArrayList();

            ArrayList myArray = new ArrayList { 12, 34, 56, 7, 8, 35, 65, 4, 4, 4, 4, };

            while ((line = Textfile.ReadLine()) != null)
            {
                myArray.Add(line);
                //Console.WriteLine(line);
            }
            ArrayList al1 = removeDups(myArray);
            Textfile.Close();

            foreach(var al in al1 )
            {
                Console.WriteLine(al);
            }

            Console.ReadKey();
        }
        Console.WriteLine();
    }
    public static ArrayList removeDups(ArrayList _array)
    {
        //int[] _array = new int[] { 1, 2, 1, 2 }
        var myArray = new System.Collections.ArrayList();

        foreach (var item in _array)
        {
            if (!myArray.Contains(item))
                myArray.Add(item);
        }
        return myArray;

    }

}