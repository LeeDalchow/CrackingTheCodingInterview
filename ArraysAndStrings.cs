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

            for (int i = 0; i < testString.Length; i++)
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
            for (int i = 0; i < testString.Length; i++)
            {
                for (int y = i + 1; y < testString.Length; y++) // loop through the remainder of the string
                {
                    if (testString[y] == testString[i]) return false;
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
            for (int i = str.Length - 1; i >= 0; i--)
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
            } // Another way to implement this would be to use a single Dict and ++ for str1 characters and -- for str2 characters. All keys should then == 0.

            // Check dictionarys are equal given that we know str1 & str2 are the same length.
            foreach (var key in keyCounterStr1.Keys)
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
            StringBuilder newStr = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
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

            StringBuilder newStr = new StringBuilder();
            char curChar = '0';
            int charCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (curChar == str[i]) charCount++;
                else
                {
                    if (curChar != '0') newStr.Append(curChar.ToString() + charCount.ToString());

                    curChar = str[i];
                    charCount = 1;
                }
            }

            newStr.Append(curChar.ToString() + charCount.ToString()); // Make sure to get final char!

            // Ideally, the following line would be at the start of the function, to pre-calculate the compressed length to avoid having to calculate the compressed string entirely.
            if (newStr.ToString().Length >= str.Length) return str; // If it's not any shorter...
            else return newStr.ToString();
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
        public static int[,] rotateImageInPlace(int[,] image) // 4-byte pixel is int data-type
        {
            // We will assume we will be rotating clockwise
            int n = image.GetLength(0); // NxN matrix

            // Step 1 - Transpose matrix
            for (int x = 0; x < n; x++)
            {
                for (int y = x; y < n; y++)
                {
                    if (x == y) continue; // if middle diagonal - skip

                    int temp = image[x, y];
                    image[x, y] = image[y, x];
                    image[y, x] = temp;
                }
            }


            // Step 2 - Flip Horizontally
            for (int y = 0; y < n; y++) // for each row (Y Cood)
            {
                int rowEnd = n - 1;
                for (int rowStart = 0; rowStart < rowEnd; rowStart++)
                { // for each element in row (x cood)
                    int temp = image[rowStart, y];
                    image[rowStart, y] = image[rowEnd, y];
                    image[rowEnd, y] = temp;
                    rowEnd--;
                }

            }
            return image;
        }

        // 7. Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column are set to 0.
        public static int[,] zeroExpands(int[,] matrix)
        {
            // Where are the 0's located?
            var xList = new List<int>();
            var yList = new List<int>();

            int xn = matrix.GetLength(0); // Total x coordinates
            int yn = matrix.GetLength(1); // Total y coordinates

            // Find the x & y coods of the 0's
            for (int x = 0; x < xn; x++)
            {
                for (int y = 0; y < yn; y++)
                {
                    if (matrix[x, y] == 0)
                    {
                        xList.Add(x);
                        yList.Add(y);
                    }
                }
            }

            // Block out all the 0's for X coods
            foreach (int x in xList)
            {
                for (int y = 0; y < yn; y++)
                {
                    matrix[x, y] = 0;
                }
            }

            // Block out of the 0's for Y Coods
            foreach (int y in yList)
            {
                for (int x = 0; x < xn; x++)
                {
                    matrix[x, y] = 0;
                }
            }

            return matrix;
        }

        /* 
         * 8. Assume you have a method isSubstring which checks if one word is a substring of another. Given two strings, s1 and s2, write code
         * to check if s2 is a rotation of s1 using only one call to isSubstring (eg. "waterbottle" is a rotation of "erbottlewat")
         */

        // Will write the isSubstring function first
        private static bool isSubString(string s1, string s2)
        {
            return s1.Contains(s2);
        }

        public static bool isRotation1stAttempt(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;
            if (s1.Length == 0) return true;

            char s1First = s1[0];

            for(int i = 0; i < s2.Length; i++)
            {
                if(s1First == s2[i]) { // Found it!
                    int half2Length = s2.Length - i;
                    if(s1.Substring(0, half2Length) == s2.Substring(i)) // The 2nd half of s2 matches s1
                    {
                        if (isSubString(s1, s2.Substring(0, s2.Length - half2Length))) return true;
                    }
                }
            }

            return false;
        }
        // Problem with this is that isSubString could be called multiple times in some cases.
        // It's also possible to form a string that would pass this check but not be a rotation, so not an ideal solution at all!
        // It would be better in this case NOT to use isSubstring and instead to calculate the exact substring location within s1 directly to do an isEqual comparison.
        // The isSubstring line would look like this instead:
        // if (s1.Substring(half2Length) == s2.Substring(0, s2.Length - half2Length)) return true;


        /*
         * The 2nd attempt is so simple... and I'll be transparant and admit I did google this one!
         * Makes me want to kick myself that I didn't spot this!!
         * 
         * In the example of:
         * 
         * s1 = "waterbottle"
         * s2 = "erbottlewat"
         * 
         * Let x = "wat" and y = "erbottle"
         * 
         * Then:
         * 
         * s1 = xy & s2 = yx
         * 
         * Therefore:
         * 
         * s1s1 = xyxy which s2 (yx) is a substring of.
         */
        public static bool isRotation2ndAttempt(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;
            if (s1.Length == 0) return true;

            string s1s1 = s1 + s1;
            return isSubString(s1s1, s2);
        }
    }
}