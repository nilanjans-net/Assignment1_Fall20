using System;
using System.Collections.Generic;
using System.Numerics;

namespace Assignment1_Fall20
{
    class Program
    {
        static void Main(string[] args)
        {

            // References https://www.geeksforgeeks.org

            int n = 5;
            PrintTriangle(n);

            int n2 = 5;
            PrintSeriesSum(n2);

            int[] A = new int[] { 1, 2, 2, 6 }; 
            bool check = MonotonicCheck(A);
            Console.WriteLine(check);
            

            int[] nums = new int[] { 3, 1, 4, 1, 5 };
            int k = 2;
            int pairs = DiffPairs(nums, k);
            Console.WriteLine(pairs);
           
            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "dis";
            int time = BullsKeyboard(keyboard, word);
            Console.WriteLine(time);

            string str1 = "goulls";
            string str2 = "gobulls";
            int minEdits = StringEdit(str1, str2);
            Console.WriteLine();
            Console.WriteLine("Answer 6 below:");
            Console.WriteLine(minEdits);

            Console.ReadKey();

        }

        public static void PrintTriangle(int x)
        {
            Console.WriteLine("Answer 1 below: ");
            try
            {
                if (x > 0)
                {
                    int i, j = 1;
                    int count = x - 1;
                    for (j = 1; j <= x; j++)
                    {
                        //start Printing Space  
                        for (i = 1; i <= count; i++)
                        {
                            Console.Write(" ");
                        }
                        count--;
                        //end Printing space
                        for (i = 1; i <= 2 * j - 1; i++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                    }
                } else
                {
                    Console.WriteLine("Please provide positive value for n");
                }
                
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintTriangle()");
            }
        }

        public static void PrintSeriesSum(int n)
        {
            Console.WriteLine();
            Console.WriteLine("Answer 2 below: ");
            try
            {
                if (n > 0)
                {
                    
                    Console.Write("The odd numbers are :");
                    int sum = 0;
                    int odd = -1;
                    for (int i = 1; i <= n; i++)
                    {
                        odd = odd + 2;
                        Console.Write(" " + odd);
        
                        sum = sum + odd;
                        
                        // Printing comma between odd numbers
                        if(i < n)
                        {
                            Console.Write(",");
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("The sum is : " + sum);
                    
                } else
                {
                    Console.WriteLine("Please provide positive number for n");
                }
                
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintSeriesSum()");
            }
        }

        public static bool MonotonicCheck(int[] n)
        {
            Console.WriteLine();
            Console.WriteLine("Answer 3 below: ");
            try
            {
                // An array of length less than or equal 2 
                // will always be monotone (either increasing or decreasing)
                if (n.Length <= 2)
                {
                    return true;
                }
                else
                {
                    bool monotoneIncreasing = true;
                    // Check if monotone increasing
                    for (int i = 1; i < n.Length; i++)
                    {
                        if(n[i] < n[i - 1])
                        {
                            monotoneIncreasing = false;
                            break;
                        }
                    }

                    bool monotoneDecreasing = true;
                    // Check if monotone increasing
                    for (int i = 1; i < n.Length; i++)
                    {
                        if (n[i] > n[i - 1])
                        {
                            monotoneDecreasing = false;
                            break;
                        }
                    }
                    return monotoneIncreasing || monotoneDecreasing;
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MonotonicCheck()");
            }
            
            return false;
        }

        public static int DiffPairs(int[] J, int k)
        {
            Console.WriteLine();
            Console.WriteLine("Answer 4 below: ");
            try
            {
                
                // Using HashSet to get unique pair count
                // the pair of numbers to be stored separated by hyphen
                // with the smaller number in the beginning followed by larger number
                HashSet<string> set = new HashSet<string>();
                // Pick all elements one by one 
                for (int i = 0; i < J.Length; i++)
                {

                    // Check if there is a pair 
                    for (int j = i + 1; j < J.Length; j++)
                    {
                        if (J[i] - J[j] == k || J[j] - J[i] == k)
                        {
                            
                            if (J[i] <= J[j]) {
                                set.Add(J[i] + "-" + J[j]);
                            }
                            else
                            {
                                set.Add(J[j] + "-" + J[i]);
                            }
                        }
                    }
                }

                return set.Count;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing DiffPairs()");
            }

            return 0;
        }

        public static int BullsKeyboard(string keyboard, string word)
        {
            int result = 0;
            Console.WriteLine();
            Console.WriteLine("Answer 5 below: ");
            try
            {
                Dictionary<char, int> map = new Dictionary<char,int>();
               
                char[] keyboardCharArray = keyboard.ToCharArray();

                // Storing all the chars of keyboard string into dictionary
                for (int i = 0; i < keyboardCharArray.Length; i++)
                {
                   map.Add(keyboardCharArray[i], i );
                }

               
                int previndex = 0;
                char[] wordCharArray = word.ToCharArray();
                for (int j = 0; j < wordCharArray.Length; j++)
                {
                    int currentindex = map[wordCharArray[j]];
                    result = result + Math.Abs(currentindex - previndex);
                    previndex = currentindex;
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing BullsKeyboard()");
            }

            return result;
        }

        public static int StringEdit(string str1, string str2)
        {
            
            try
            {
                int m = str1.Length;
                int n = str2.Length;

                // If first string is empty, the only option is to 
                // insert all characters of second string into first 
                if (m == 0)
                {
                    return n;
                }

                // If second string is empty, the only option is to 
                // remove all characters of first string 
                if (str2.Length == 0)
                {
                    return str1.Length;
                }

                // If last characters of two strings are same, nothing 
                // much to do. Ignore last characters and get count for 
                // remaining strings. 
                if (str1[m - 1] == str2[n - 1])
                    return StringEdit(str1.Substring(0, m - 1), str2.Substring(0, n-1));

                // If last characters are not same, consider all three 
                // operations on last character of first string, recursively 
                // compute minimum cost for all three operations and take 
                // minimum of three values. 

                int inserts = StringEdit(str1, str2.Substring(0, n - 1));
                int removes = StringEdit(str1.Substring(0, m - 1), str2);
                int replaces = StringEdit(str1.Substring(0, m - 1), str2.Substring(0, n - 1));


                return 1 + Math.Min(replaces, Math.Min(inserts, removes));
            }
            catch
            {
                Console.WriteLine("Exception occured while computing StringEdit()");
            }

            return 0;
        }
    }

}



