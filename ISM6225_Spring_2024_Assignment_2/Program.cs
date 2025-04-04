using System;
using System.Collections.Generic;
using System.Reflection;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4,3,2,7,8,2,3,1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 47;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Write your code here
                List<int> sortedList = nums.Order().ToList();
                Console.WriteLine(string.Join(",", sortedList));
                List<int> missingNumbers = new List<int>();
                //Missing numbers anywhere in the range 1 to n
                for (int i = 1; i <= sortedList.Count; i++)
                {
                    //Used Contains to check for presence from 1 to nums.Length
                    if (!sortedList.Contains(i))
                    {
                        missingNumbers.Add(i);
                    }
                }
                return missingNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Write your code here
                //Split into even and odd, then concatenate
                List<int> evenNumbers = new List<int>();
                List<int> oddNumbers = new List<int>();
                foreach (int num in nums)
                {
                    if (num % 2 == 0)
                    {
                        evenNumbers.Add(num);
                    }
                    else
                    {
                        oddNumbers.Add(num);
                    }
                }
                evenNumbers.AddRange(oddNumbers);
                return evenNumbers.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Write your code here
                //Same element used twice should not be allowed, return first found
                //Used dictionary to track seen numbers and check for complement
                Dictionary<int, int> numDict = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    if (numDict.ContainsKey(complement))
                    {
                        return new int[] { numDict[complement], i };
                    }
                    if (!numDict.ContainsKey(nums[i]))
                    {
                        numDict[nums[i]] = i;
                     }
                }
                return numDict.SelectMany(kvp => new int[] { kvp.Key, kvp.Value }).ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Write your code here
                Array.Sort(nums);
                int n = nums.Length;
                //Consider product of 3 largest OR 2 smallest × largest
                int maxProduct = Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3], nums[0] * nums[1] * nums[n - 1]);
                return maxProduct;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Write your code here
                //Return "0" for zero input, use loop for positive input
                if (decimalNumber == 0)
                    return "0";
                string binary = "";
                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary;
                    decimalNumber = decimalNumber / 2;
                }
                return binary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Write your code here
                // Use binary search comparing mid and end
                int start = 0;
                int end = nums.Length - 1;
                while(start < end)
                {
                    int mid = (start + end) / 2;
                    if (nums[mid] > nums[end])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid;
                    }
                }
                return nums[start];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here
                //Negative number not a palindrome
                if (x < 0)
                    return false;
                int original = x;
                int reversed = 0;
                //Single digit number(always a palindrome)
                //Reverse the number and compare with original
                while (x > 0)
                {
                    int num = x % 10;
                    reversed = reversed * 10 + num;
                    x = x / 10;
                }
                if (reversed == original)
                    return true;
                else
                    return false; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here
                //n out of bounds (<0 or >30)
                if ( n<0 || n>30)
                    throw new ArgumentOutOfRangeException("n", "Input must be between 0 and 30.");
                if (n <= 1)
                    return n;
                int a = 0;
                int b = 1;
                int c = 0;
                for(int i=2;i<=n;i++)
                {
                    c = a + b;
                    a = b;
                    b = c;
                }
                return c; 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
