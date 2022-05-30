﻿// Simple Test Harness. Simply call the functions to be tested below:


using CrackingTheCodingInterview;

Console.WriteLine("Chapter 1 - Arrays & Strings");
Console.WriteLine("Question 1");
if (!ArraysAndStrings.isAllUnique("qwerty")) Console.WriteLine("FAIL");
if (ArraysAndStrings.isAllUnique("qwertyy")) Console.WriteLine("FAIL");

Console.WriteLine("Question 1b");
if (!ArraysAndStrings.isAllUniqueNoDS("qwerty")) Console.WriteLine("FAIL");
if (ArraysAndStrings.isAllUniqueNoDS("qwertyy")) Console.WriteLine("FAIL");

Console.WriteLine("Question 2");
string tmp = "qwerty";
ArraysAndStrings.reverse(ref tmp);
if (tmp != "ytrewq") Console.WriteLine("FAIL");

Console.WriteLine("Question 3");
if (!ArraysAndStrings.isPermutation("ABGYRVF", "ABVRYGF")) Console.WriteLine("FAIL");
if (ArraysAndStrings.isPermutation("ABGYRVF", "ABVRYGFB")) Console.WriteLine("FAIL");
if (ArraysAndStrings.isPermutation("ABGYRVF", "ABVRYG")) Console.WriteLine("FAIL");
if (ArraysAndStrings.isPermutation("ABGYRVF", "ABVRYGA")) Console.WriteLine("FAIL");
if (ArraysAndStrings.isPermutation("ABGYRFF", "ABVRYGG")) Console.WriteLine("FAIL");

Console.WriteLine("Question 4");
if (!(ArraysAndStrings.urlEncodeSpaces("Mr John Smith ") == "Mr%20John%20Smith%20")) Console.WriteLine("FAIL");

Console.WriteLine("Question 5");
if(!(ArraysAndStrings.compress("aabcccccaaa") == "a2b1c5a3")) Console.WriteLine("FAIL");
if (!(ArraysAndStrings.compress("aggjncvcctyjfssaaaaaaaaaaaaaa") == "a1g2j1n1c1v1c2t1y1j1f1s2a14")) Console.WriteLine("FAIL");
if (!(ArraysAndStrings.compress("b") == "b")) Console.WriteLine("FAIL");
if (!(ArraysAndStrings.compress("ba") == "ba")) Console.WriteLine("FAIL");

Console.WriteLine("Question 6");
int[,] sixBy6Array = fill2DArray(new int[6, 6]);
Console.WriteLine("Original Matrix:");
print2DArray(sixBy6Array);
int [,] matrixResult = ArraysAndStrings.rotateImage(sixBy6Array);
Console.WriteLine("Rotated clockwise by 90 degrees:");
print2DArray(matrixResult);


Console.WriteLine("Question 6b");
int[,] NineBy9Array = fill2DArray(new int[9, 9]);
Console.WriteLine("Original Matrix:");
print2DArray(NineBy9Array);
matrixResult = ArraysAndStrings.rotateImageInPlace(NineBy9Array);
Console.WriteLine("Rotated clockwise by 90 degrees:");
print2DArray(matrixResult);

Console.WriteLine("Question 7");
int[,] TenBy15Array = fill2DArray(new int[10, 15]);
// Set some random 0's
TenBy15Array[5, 7] = 0;
TenBy15Array[8, 14] = 0;
TenBy15Array[3, 3] = 0;
Console.WriteLine("Original Matrix:");
print2DArray(TenBy15Array);
matrixResult = ArraysAndStrings.zeroExpands(TenBy15Array);
Console.WriteLine("Zeros expanded on x and y:");
print2DArray(matrixResult);

Console.WriteLine("Question 8 - 1st Attempt");
if (!ArraysAndStrings.isRotation1stAttempt("waterbottle", "erbottlewat")) Console.WriteLine("FAIL");
if (ArraysAndStrings.isRotation1stAttempt("waterbottle", "erbottlewa")) Console.WriteLine("FAIL");
if (ArraysAndStrings.isRotation1stAttempt("waterbottle", "erbottlewatt")) Console.WriteLine("FAIL");
if (ArraysAndStrings.isRotation1stAttempt("waterbottle", "abcgdgfdgy")) Console.WriteLine("FAIL");
if (!ArraysAndStrings.isRotation1stAttempt("wat12erbottle", "erbottlewat12")) Console.WriteLine("FAIL");

// This is the example where my 1st attempt falls over. See comments below function for explanation.
if (ArraysAndStrings.isRotation1stAttempt("123erbottle", "3erbottl123")) Console.WriteLine("FAIL (But expected)");

Console.WriteLine("Question 8 - 2nd Attempt");
if (!ArraysAndStrings.isRotation2ndAttempt("waterbottle", "erbottlewat")) Console.WriteLine("FAIL");
if (ArraysAndStrings.isRotation2ndAttempt("waterbottle", "erbottlewa")) Console.WriteLine("FAIL");
if (ArraysAndStrings.isRotation2ndAttempt("waterbottle", "erbottlewatt")) Console.WriteLine("FAIL");
if (ArraysAndStrings.isRotation2ndAttempt("waterbottle", "abcgdgfdgy")) Console.WriteLine("FAIL");
if (!ArraysAndStrings.isRotation2ndAttempt("wat12erbottle", "erbottlewat12")) Console.WriteLine("FAIL");

// From previous one - showing it now works
if (ArraysAndStrings.isRotation2ndAttempt("123erbottle", "3erbottl123")) Console.WriteLine("FAIL (But NOT expected)");

Console.WriteLine("Finished!");


// Provided for help debugging 2D array questions
static void print2DArray<T>(T[,] matrix)
{
    for (int y = 0; y < matrix.GetLength(1); y++)
    {
        for (int x = 0; x < matrix.GetLength(0); x++)
        {
            Console.Write(matrix[x, y] + "\t");
        }
        Console.WriteLine();
    }
}
static int[,] fill2DArray(int[,] matrix)
{
    int counter = 0;
    for (int y = 0; y < matrix.GetLength(1); y++)
    {
        for (int x = 0; x < matrix.GetLength(0); x++)
        {
            counter++;
            matrix[x, y] = counter;
        }
    }
    return matrix;
}