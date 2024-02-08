using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentApp
{
    internal class SortArrayWithOneLoop
    {
        public static void Main(string[] args)
        {
            int[] arr = [1, 0002, 1, 2, 8973, 0004, 2, 1];

            int[] sortedArray=null; 

            sortedArray = SortArrayOneLoop(arr);
            sortedArray = RemoveDups(arr); 
            for (int i = 0; i < sortedArray.Length;  i++) {
                if (sortedArray[i] != 0)
                    Console.WriteLine(sortedArray[i]  +" ");
            }
           
        }

        private static int[] SortArrayOneLoop(int[] _unsortedArray)
        {
            for (int element = 0; element < _unsortedArray.Length-1; element++)
            {
                if (_unsortedArray[element] > _unsortedArray[element + 1])
                {
                    int swap = _unsortedArray[element];
                    _unsortedArray[element] = _unsortedArray[element+1];
                    _unsortedArray[element+1] = swap;
                    element = -1;
                }
            }
            return _unsortedArray;
        }

        private static int[] RemoveDups(int[] arr)
        {
            int[] _unique = new int[arr.Length];
            int counter = 0;
            bool duplicate;
            for (int current = 0; current < arr.Length; current++)
            {
                duplicate = false;
                for (int element = 0; element < _unique.Length; element++)
                {
                    if(arr[current] == _unique[element])
                    {
                        duplicate = true;
                        continue;
                    }                   
                }
                if (!duplicate)
                {
                    _unique[counter] = arr[current];
                    counter++;                    
                }
               
            }
            return _unique;


        }


    }
}
