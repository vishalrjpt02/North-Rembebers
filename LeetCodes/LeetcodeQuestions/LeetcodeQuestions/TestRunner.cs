public class TestRunner
{
    public static void Main(string[] args)
    {
        // test case runner for MergSort function
        int m = 5;
        int[] nums2 = [0,0,0,1,3,5, 6, 7, 8, 9];
        int[] nums1 = new int[nums2.Length +m];
        nums1[0] = 1;
        nums1[1] = 2;
        nums1[2] = 3;
        nums1[3] = 4;  
        nums1[4] = 5;
        //(nums1 ,m,nums2,nums2.Length);
        string output  = REVERSE("VISHAL");
        Console.WriteLine(output);

    }

    public static string REVERSE(string name)
    {
        int c = 0;
        char []arr = name.ToCharArray();
        char []outn = new char[arr.Length];
        for(int i=arr.Length -1 ; i>=0 ;i-- )
        {
            outn[c] = arr[i];
            c++;
            //Console.WriteLine(outn[i]);
        }
        //Console.WriteLine($"output : {outn.ToString()}");
        var output = string.Join("", outn);
        
        return output;
    }

    
    //
    // public static void MergSortedArray(int[] nums1, int m, int[] nums2, int n)
    // {
    //     int last = m + n -1;
    //      
    //     while (m >0 && n >0 )
    //     {
    //         if (nums1[m-1] > nums2[n-1])
    //         {
    //             nums1[last] = nums1[m - 1];
    //             m--;
    //         }
    //         else
    //         {
    //             nums1[last] = nums2[n - 1];
    //             n--;
    //         }
    //         
    //         last--;
    //     }
    //
    //     while (n>0)
    //     {
    //         nums1[m] = nums1[last];
    //         n--;
    //         last--;
    //     }
    //     
    //     
    //     
    //     for (int i = 0; i < nums1.Length; i++)
    //     {
    //         Console.WriteLine(nums1[i]);
    //     }
    //     
    //     //how to merg two array.
    //     ///nums1.CopyTo(nums1,0);
    //     /// nums.sort();
    //
    // }
    //
    //
    // public static void RemoveDuplicates(int[] nums , int n)
    // {
    //     int start = 0;
    //
    //     while (start < nums.Length)
    //     {
    //         
    //     }
    //     
    // }
    
}