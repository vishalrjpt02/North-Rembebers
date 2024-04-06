class Program
{
    public static void Main(string []args)
    {
        Console.WriteLine("please enter the size");
        //int size = Convert.ToInt32(Console.ReadLine());
        //int[] Elements = toInt32(Console.ReadLine()  new int[size];
        //int[] eele = String(Console.ReadLine()).ToArray(Int32)
        //in
        //for(int i = 0; i < size; i++)
        //{
        //    Console.WriteLine("please enter thee  number"); 
        //    Elements[i]= Convert.ToInt32(Console.ReadLine());
        //}

        int[] Elements = { 3, 1, 2, 5, 3 };

        PrintDupsAndMissing(Elements);
    }

    private static void PrintDupsAndMissing(int[] elements)
    {
        Array.Sort(elements); // {1,2,3,3,5}
        
        int[] _outComes = new int[elements.Length];
        int[] _missings = new int[elements.Length];
        for(int i = 0;i < elements.Length-1;i++)
        {
            if (elements[i] == elements[i + 1])
            {
                if(!_outComes.Contains(elements[i]))
                {
                    _outComes.Append(elements[i]);
                }
            }
            if (!(elements[i] <= elements[i + 1]))
            {
                _missings[i] = elements[i+1];
            }
        }
        if (_missings[0] == 0)
        {
            _missings[0] = _outComes[_outComes.Length-1]+1;
        }
        foreach(int i in _outComes)
        {
            Console.WriteLine(_outComes[i]);
        }
    }


    private static bool ValidateDetails(string fname, string lname, string uName, string pass, string email)
    {
        // name  validation.
        if ((fname.Contains("/!@#$%^&*()____++=-0987654321"))|| lname.Contains("/!@#$%^&*()____++=-0987654321"))
        {
            return false;
        }
        if(uName.Contains("/ !@#$%^&*()____++=-0987654321")&& uName.Contains("ASDFGHJKLZXCVBNMQWERTYUIOPzxcvbnmasdfghjklqwertyuiop")
        {

        }

    }



}