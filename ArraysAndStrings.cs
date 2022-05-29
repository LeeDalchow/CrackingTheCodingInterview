using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview
{
    // Chapter 1 - Arrays & Strings
    public static class ArraysAndStrings
    {

        // Question 1 - Implement an algorithm to determine if a string has all unique characters.
        public static bool isAllUnique(string testString)
        {
            var keyCounter = new Dictionary<char, bool>();

            for(int i = 0; i < testString.Length; i++)
            {
                char charToTest = testString[i];
                
                if(keyCounter.ContainsKey(charToTest)) return false; 
                else keyCounter.Add(charToTest, true);
            }

            return true; // If it's got down here, it must be unique
        }

        // 1b. What if you cannot use additional data structures?
        public static bool isAllUniqueNoDS(string testString)
        {
            for(int i = 0; i < testString.Length;i++)
            {
                for(int y = i + 1; y < testString.Length; y++) // loop through the remainder of the string
                {
                    if(testString[y] == testString[i]) return false;
                }
            }

            return true; // if it gets down here, it's unique
        }

        // 2. Implement a function void reverse(char* str) in C or C++ which reverses a null-terminated string.
        // Lee: I will write this in C# below WITHOUT using the in-build reverse() function in the string class.
        public static void reverse(ref string str)
        {
            //str = new String(str.Reverse().ToArray()); // real-world solution!

            char[] newStr = str.ToCharArray(); // Better to pre-define entire string length to avoid recreating string each iteration.
            int y = 0;
            for (int i = str.Length-1; i >= 0; i--)
            {
                newStr[y] = str[i];
                y++;
            }
            str = new string(newStr);
        }

        // 3. Given two strings, write a method to decide if one is a permutation of the other.
        public static bool isPermutation(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false; // We can assume now onwards that the strings are the same length

            var keyCounterStr1 = new Dictionary<char, int>();
            var keyCounterStr2 = new Dictionary<char, int>();

            // Build Map of characters to counts
            for (int i = 0; i < str1.Length; i++)
            {
                if (keyCounterStr1.ContainsKey(str1[i])) keyCounterStr1[str1[i]]++;
                else keyCounterStr1.Add(str1[i], 1);

                if (keyCounterStr2.ContainsKey(str2[i])) keyCounterStr2[str2[i]]++;
                else keyCounterStr2.Add(str2[i], 1); // Code Smell - duplicated code. Could probably put this into a seperate method... but given how small it is I'll leave it as it is for now.
            }

            // Check dictionarys are equal given that we know str1 & str2 are the same length.
            foreach(var key in keyCounterStr1.Keys)
            {
                if (keyCounterStr1[key] != keyCounterStr2[key]) return false;
            }

            return true;
        }

        /* 4. Write a method to replace all spaces in a string with '%20%'. You may assume that
         * the string has sufficient space at the end of the string to hold the additional characters,
         * and that you are given the "true" length of the string. (Note: If implementing in Java, 
         * please use a character array so that you can perform this operation in place.)
         * EXAMPLE
         * Input: "Mr John Smith"
         * Output: "Mr%20%John%20Smith"
         * 
         * Lee: In the context of C#, we don't need to worry about the total length of the string, as this is a C
         * concept where strings are of fixed length and null-terminated.
        */
        public static string urlEncodeSpaces(string str)
        {
            //return str.Replace(" ", "%20"); // Real world solution!

            string newStr = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ') newStr = newStr + "%20";
                else newStr = newStr + str[i];
            }

            return newStr;
        }
        /* Problem with the above is that it is not very efficient for long-strings as it will recreate the string in memory each
         * time it appends a new character to newStr. A more efficient way may be to calculate the final length of the string
         * before building it in memory, however as the question assumes we already know this figure, I won't optimise the algorithm in this way.
         * UPDATE: A StringBuffer would do exactly this!
         */

        /*
         * 5. Implement a method to perform basic string compression using the counts of repeated characters. For example
         * the string aabcccccaaa would become a2b1c5a3. If the "compressed" string would not become smaller than
         * the original string, your method should return the original string. You can assume the string has only upper
         * and lower case letters (a-z).
         */
        public static string compress(string str)
        {
            if (str.Length == 0) return "";

            string newStr = "";
            char curChar = '0';
            int charCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (curChar == str[i]) charCount++;
                else
                {
                    if (curChar != '0') newStr = newStr + curChar.ToString() + charCount.ToString();

                    curChar = str[i];
                    charCount = 1;
                }
            }

            newStr = newStr + curChar + charCount.ToString(); // Make sure to get final char!
            return newStr;
        }

        /*
         * 6. Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes, write a method to rotate
         * the image by 90 degrees.
         */
        public static int[,] rotateImage(int[,] image) // 4-byte pixel is int data-type
        {
            // We will assume we will be rotating clockwise

            int n = image.GetLength(0); // NxN matrix
            
            int[,] result = new int[n, n];

            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    int newX = n - 1 - y; // rows become columns from right-to-left
                    int newY = x;
                    result[newX, newY] = image[x, y];

                }
            }
            return result;
        }


        // 6b. Can you do this in-place?
    }
}
