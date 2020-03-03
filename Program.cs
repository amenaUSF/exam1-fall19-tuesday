using System;
using System.Collections.Generic;
using System.Linq;

namespace exam1_fall19_tuesday
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question no. 1a");
            ques1a();

            Console.WriteLine("Question no. 1b");
            ques1b();

            Console.WriteLine("Question no. 2");
            Console.WriteLine(IsArmstrong(153));
            Console.WriteLine(IsArmstrong(123));

            Console.WriteLine("Question no. 3");
            Console.WriteLine(NumJewelsInStones("aA", "aAAbbbb"));
            Console.WriteLine("Question no. 3");
            Console.WriteLine(NumJewelsInStones("z", "ZZ"));

            Console.WriteLine("Question no. 4");
            int[] a = { 2, 2, 1 };
            Console.WriteLine(SingleNumber(a));
            Console.WriteLine("Question no. 4");
            int[] aa = { 4, 1, 2, 1, 2 };
            Console.WriteLine(SingleNumber(aa));


            Console.WriteLine("Question no. 5");
            int[] numbers = { 2, 5, 7, 11, 15 };
            int target = 9;
            DisplayArray(TwoSum(numbers, target));

        }

        public static void DisplayArray(int[] a)
        {
            foreach (int x in a)
                Console.WriteLine(x);
        }
        public static void ques1a()
        {
            int a = 10, b = 15;
            int max = 0, step;
            if (a > b)
                max = a;
            else
                max = b;
            step = max;
            while (true)
            {
                if (max % a == 0 && max % b == 0)
                    break;
                max += step;
            }
            Console.WriteLine(max);
        }

        public static void ques1b()
        {
            int value = 0, counter = 0, n = 5;
            for (int i = 0; i < n; i++)
            {
                value = i + 1;
                counter = n - 1;
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(value + " ");
                    value = value + counter;
                    counter = counter - 1;
                }
                Console.Write("\n");
            }
        }//end of ques1b

        public static bool IsArmstrong(int n)
        {
            string s = n.ToString();
            int k = s.Length;
            int sum = 0;
            int n2 = n;

            while (n / 10 != 0)
            {
                int x = n % 10;
                n = n / 10;
                sum = sum + Convert.ToInt32((Math.Pow(x, k)));
            }
            sum = sum + Convert.ToInt32((Math.Pow(n, k)));

            if (sum == n2)
                return true;
            else
                return false;
        }//end of isarmstrong

        //question3
        public static int NumJewelsInStones(string J, string s)
        {
            int cnt = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (J.Contains(s[i]) == true)
                    cnt++;
            }
            return cnt;
        }

        //question4
        public static int SingleNumber(int[] nums)
        {
            Dictionary<int, int> d = nums.Distinct().ToDictionary(key => key, value => 0);
            int ret = 0;


            for (int i = 0; i < nums.Length; i++)
            {
                if (d.ContainsKey(nums[i]) == true)
                    d[nums[i]]++;
            }

            foreach (KeyValuePair<int, int> item in d)
            {
                if (item.Value == 1)
                {
                    ret = item.Key;
                    break;
                }
            }

            return ret;
        }

        //question5
        public static int[] TwoSum(int[] numbers, int target)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            int x = 0;
            int y = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (d.ContainsKey(numbers[i]) == false)
                { d.Add(numbers[i], i); }

                x = target - numbers[i];    //returns the value of x we need to make it target

                int y2;
                if (d.TryGetValue(x, out y2) == true)
                {
                    y = y2;
                    break;

                }
            }
            int[] a = { y, x };
            return a;
        }

        public static int[] TwoSum2(int[] numbers, int target)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            int p = 0;
            int q = numbers.Length - 1;
           
            for (int i = 0; i < numbers.Length; i++)
            {
               int x = target - numbers[p];    //returns the value of x we need to make it target

                if (numbers[q] == x)
                { break; }
                if (numbers[q] > x)
                    q--;
                else if (numbers[q] < x)
                    p++;
                
            }
            return new int[] { p, q };
        }//end of twosum2

        public static int[] TwoSum3(int[] numbers, int target)
        {
            Dictionary<int, int> d = numbers.Distinct().ToDictionary(key => key, value => 0);
            int p = 0;
            int q = numbers.Length - 1;

            for (int i = 0; i < d.Count; i++)
            {
                int x = target - d.Keys.ElementAt(i);    //returns the value of x we need to make it target
                if (d.ContainsKey(x))
                {
                    p = i;
                    break;
                }

            }
            return new int[] { p, q };
        }//end of twosum3
    }
}
