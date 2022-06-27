using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview
{
    // Chapter 1 - Arrays & Strings
    public static class Chap1ArraysAndStrings
    {

        // Question 1 - Implement an algorithm to determine if a string has all unique characters.
        public static bool isAllUnique(string testString)
        {
            var keyCounter = new Dictionary<char, bool>(); // I chose a Dictionary becuase the Dict.ContainsKey function is more efficient than List.Contains

            for (int i = 0; i < testString.Length; i++) // For each character
            {
                char charToTest = testString[i];

                if (keyCounter.ContainsKey(charToTest)) return false;
                else keyCounter.Add(charToTest, true);
            }

            return true; // If it's got down here, it must be unique
        }

        // 1b. What if you cannot use additional data structures?
        public static bool isAllUniqueNoDS(string testString)
        {
            for (int i = 0; i < testString.Length; i++) // For each character
            {
                for (int y = i + 1; y < testString.Length; y++) // For each character in the rest of the string.
                {
                    if (testString[y] == testString[i]) return false;
                }
            }

            return true; // if it gets down here, it's unique
        }

        // 2. Implement a function void reverse(char* str) in C or C++ which reverses a null-terminated string.
        // Lee: I will write this in C# below WITHOUT using the in-built reverse() function in the string class.
        public static void reverse(ref string str)
        {
            //str = new String(str.Reverse().ToArray()); // real-world solution!

            char[] newStr = str.ToCharArray(); // Better to pre-define entire string length to avoid recreating string each iteration.
            int y = 0;
            for (int i = str.Length - 1; i >= 0; i--) // For each character in the string
            {
                newStr[y] = str[i];
                y++;
            }
            str = new string(newStr);
        }

        // 3. Given two strings, write a method to decide if one is a permutation of the other.
        public static bool isPermutation(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false; // We can assume from now onwards that the strings are the same length

            var keyCounterStr = new Dictionary<char, int>();

            // Build Map of characters to counts
            for (int i = 0; i < str1.Length; i++)
            {
                if (keyCounterStr.ContainsKey(str1[i])) keyCounterStr[str1[i]]++; // +1 for str1 characters
                else keyCounterStr.Add(str1[i], 1);

                if (keyCounterStr.ContainsKey(str2[i])) keyCounterStr[str2[i]]--; // -1 for str2 characters
                else keyCounterStr.Add(str2[i], -1);
            }

            // If it is a Permutation, all keys should now == 0
            foreach (var key in keyCounterStr.Keys)
            {
                if (keyCounterStr[key] != 0) return false;
            }

            return true; // If we get here, it's a Permutation!
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
         * concept where strings are of fixed length and null-terminated. C# handles all of this for you.
        */
        public static string urlEncodeSpaces(string str)
        {
            //return str.Replace(" ", "%20"); // Real world solution!

            StringBuilder newStr = new StringBuilder();
            for (int i = 0; i < str.Length; i++) // for each char in str
            {
                if (str[i] == ' ') newStr.Append("%20");
                else newStr.Append(str[i]);
            }

            return newStr.ToString();
        }

        /*
         * 5. Implement a method to perform basic string compression using the counts of repeated characters. For example
         * the string aabcccccaaa would become a2b1c5a3. If the "compressed" string would not become smaller than
         * the original string, your method should return the original string. You can assume the string has only upper
         * and lower case letters (a-z).
         */
        public static string compress(string str)
        {
            if (str.Length == 0) return "";

            StringBuilder newStr = new StringBuilder(); // Used to avoid expensive string concatanation within the loop.
            char curChar = '0'; // Null-like value, as this is not a valid char in str.
            int charCount = 0;
            int originalStrLength = str.Length; // to avoid processing each time we need it.

            for (int i = 0; i < originalStrLength; i++) // for each char in str
            {
                if (curChar == str[i]) charCount++;
                else
                {
                    if (curChar != '0')
                    {
                        if (_addCharAndCheckLength(newStr, curChar, charCount, originalStrLength)) return str;
                    }

                    curChar = str[i];
                    charCount = 1;
                    
                }
            }

            if (_addCharAndCheckLength(newStr, curChar, charCount, originalStrLength)) return str; // Make sure not to forget final char!

            return newStr.ToString();
        }

        // Returns True if the the length of the new string is greater than the length of the original string, False if not.
        private static bool _addCharAndCheckLength(StringBuilder newStr, char curChar, int charCount, int originalStrLength)
        {
            newStr.Append(curChar.ToString() + charCount.ToString()); 
            if (newStr.Length >= originalStrLength) return true; // If it's not going to be any shorter, just return the original string
            else return false;
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
                for (int y = 0; y < n; y++) // for each x,y cord
                {
                    // rows become the columns but from right-to-left
                    int newX = n - 1 - y; // New Columns start from right, and slowly move to the left as we go down original Y Axis.
                    int newY = x; // And then move down the new column as we move across the original X axis.
                    result[newX, newY] = image[x, y];

                }
            }
            return result;
        }


        // 6b. Can you do this in-place?
        public static void rotateImageInPlace(ref int[,] image) // 4-byte pixel is int data-type
        {
            // We will assume we will be rotating clockwise

            // Step 1 - Transpose matrix
            _transpose(ref image);

            // Step 2 - Flip Horizontally
            _flipHorizontally(ref image);
        }

        private static void _transpose(ref int[,] image)
        {
            int n = image.GetLength(0); // Assume matrix is NxN

            for (int x = 0; x < n; x++)
            {
                for (int y = x; y < n; y++) // For each x,y cord
                {
                    if (x == y) continue; // if middle diagonal - skip

                    // Swap X & Y
                    int temp = image[x, y];
                    image[x, y] = image[y, x];
                    image[y, x] = temp;
                }
            }
        }

        private static void _flipHorizontally(ref int[,] image)
        {
            int n = image.GetLength(0); // Assume matrix is NxN

            for (int y = 0; y < n; y++) // for each row (Y Cord)
            {
                int rowPosEnd = n - 1;
                int rowPosStart = 0;

                // Swap elements left-to-right, and slowly move the pointers towards each other in the middle.
                while (rowPosStart < rowPosEnd)
                {
                    int temp = image[rowPosStart, y];
                    image[rowPosStart, y] = image[rowPosStart, y];
                    image[rowPosEnd, y] = temp;

                    rowPosStart++;
                    rowPosEnd--;
                };
            }
        }

        // 7. Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column are set to 0.
        public static int[,] zeroExpands(int[,] matrix)
        {
            // Where are the 0's located?
            var xZeros = new List<int>();
            var yZeros = new List<int>();

            int xn = matrix.GetLength(0); // Total x coordinates
            int yn = matrix.GetLength(1); // Total y coordinates

            // Find the x & y coods of the 0's
            // Was debating making this a seperate method, but I think the below is bespoke enough for it not to be required.
            for (int x = 0; x < xn; x++)
            {
                for (int y = 0; y < yn; y++)
                {
                    if (matrix[x, y] == 0)
                    {
                        xZeros.Add(x);
                        yZeros.Add(y);
                    }
                }
            }

            // Block out all the 0's for X coods
            foreach (int x in xZeros)
            {
                _givenXReplaceYWithValue(ref matrix, x, 0);
            }

            // Block out of the 0's for Y Coods
            foreach (int y in yZeros)
            {
                _givenYReplaceXWithValue(ref matrix, y, 0);
            }

            return matrix;
        }

        private static void _givenXReplaceYWithValue(ref int[,] matrix,int x, int newValue)
        {
            int yn = matrix.GetLength(1); // Total y coordinates

            for (int y = 0; y < yn; y++)
            {
                matrix[x, y] = newValue;
            }
        }

        private static void _givenYReplaceXWithValue(ref int[,] matrix, int y, int newValue)
        {
            int xn = matrix.GetLength(0); // Total x coordinates

            for (int x = 0; x < xn; x++)
            {
                matrix[x, y] = newValue;
            }
        }

        /* 
         * 8. Assume you have a method isSubstring which checks if one word is a substring of another. Given two strings, s1 and s2, write code
         * to check if s2 is a rotation of s1 using only one call to isSubstring (eg. "waterbottle" is a rotation of "erbottlewat")
         */

        // Will write the isSubstring function first
        private static bool _isSubString(string s1, string s2)
        {
            return s1.Contains(s2);
        }

        // This was my 1st attempt... which while it 'works', it's not the correct solution for the above problem.
        public static bool isRotation1stAttempt(string s1, string s2)
        {
            // Basic sense-checking here
            if (s1.Length != s2.Length) return false;
            if (s1.Length == 0) return true;

            for(int i = 0; i < s2.Length; i++) // Loop through s2 to find where 1st letter of s2 begins.
            {
                if(s1[0] == s2[i]) { // Found it!
                    int s2Intersection = s2.Length - i; // Position of 1st char of s1 in s2.
                    if(s1.Substring(0, s2Intersection) == s2.Substring(i)) // Does the remainder of s2 match the first part of s1?
                    {
                        if (_isSubString(s1, s2.Substring(0, s2.Length - s2Intersection))) return true; // Does the 1st part of s2, match the 2nd part of s1?

                        // Better implementation below, although this does not use _isSubString, so commented out.
                        // if (s1.Substring(s2Intersection) == s2.Substring(0, s2.Length - s2Intersection)) return true; // Does the 1st part of s2, match the 2nd part of s1?
                    }
                }
            }

            return false;
        }
        /* Problem with this is that _isSubString could be called multiple times in some cases.
         * It's also possible to form a string that would pass this check but not be a rotation, so this is a very bad implementation
         * False positives can be removed by not using _isSubstring and instead to use the exact character positions as demonstrated in the commented out line.#
         */
        


        /*
         * The 2nd attempt is so simple... and I'll be transparant and admit I did google this one!
         * Makes me want to kick myself that I didn't spot this!!
         * 
         * In the example of:
         * s1 = "waterbottle"
         * s2 = "erbottlewat"
         * 
         * Let x = "wat" and y = "erbottle"
         * 
         * Then:
         * s1 = xy & s2 = yx
         * 
         * Therefore:
         * s1s1 = xyxy which s2 (yx) is a substring of.
         */
        public static bool isRotation2ndAttempt(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;
            if (s1.Length == 0) return true;

            string s1s1 = s1 + s1;
            return _isSubString(s1s1, s2);
        }
    }
}