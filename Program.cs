// Simple Test Harness. Simply calls the functions to be tested below.
// I have not optimised this module for efficiency. It's meant to be a quick-and-dirty test harness.


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
ArraysAndStrings.rotateImageInPlace(ref NineBy9Array);
Console.WriteLine("Rotated clockwise by 90 degrees:");
print2DArray(NineBy9Array);

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

// =================================================================================================================

Console.WriteLine("Chapter 2 - Linked Lists");
Console.WriteLine("Question 1");
var testLI = produceLinkedList();
testLI.AddLast(7); // Add another 7
if(testLI.Count <= (LinkedListQuestions.removeDuplicates(testLI)).Count) Console.WriteLine("FAIL");


Console.WriteLine("Question 1b");

testLI = produceLinkedList();
testLI.AddLast(7); // Add another 7
if (testLI.Count <= (LinkedListQuestions.removeDuplicatesInPlace(testLI)).Count) Console.WriteLine("FAIL");

Console.WriteLine("Question 2");
testLI = produceLinkedList();
if (LinkedListQuestions.findKLastElement(testLI, 0).Value != 8) Console.WriteLine("FAIL");
if (LinkedListQuestions.findKLastElement(testLI,1).Value != 7) Console.WriteLine("FAIL");
if (LinkedListQuestions.findKLastElement(testLI, 2).Value != 6) Console.WriteLine("FAIL");
if (LinkedListQuestions.findKLastElement(testLI, 3).Value != 100) Console.WriteLine("FAIL");
if (LinkedListQuestions.findKLastElement(testLI, 4).Value != 30) Console.WriteLine("FAIL");

Console.WriteLine("Question 3");
var testSLI = produceSinglyLinkedList();
var node1 = testSLI.First;
var node1Val = testSLI.First.Value;
LinkedListQuestions.removeNodeFromList(ref node1);
if (testSLI.First.Value == node1Val) Console.WriteLine("FAIL!");


Console.WriteLine("Question 4");
testSLI = produceSinglyLinkedList();
testSLI = LinkedListQuestions.partitionLinkedList(testSLI, 8);
Console.WriteLine(String.Join(",", testSLI.ToArray()));


Console.WriteLine("Question 5");
var n1 = new LinkedList<int>();
n1.AddLast(7);
n1.AddLast(1);
n1.AddLast(6);
var n2 = new LinkedList<int>();
n2.AddLast(5);
n2.AddLast(9);
n2.AddLast(2);
var n3 = LinkedListQuestions.addNumbers(n1, n2);
if (String.Join(",", n3.ToArray()) != "2,1,9") Console.WriteLine("FAIL!");

n1 = new LinkedList<int>();
n1.AddLast(9);
n1.AddLast(9);
n1.AddLast(9);
n2 = new LinkedList<int>();
n2.AddLast(9);
n2.AddLast(9);
n2.AddLast(9);
n3 = LinkedListQuestions.addNumbers(n1, n2);
if (String.Join(",", n3.ToArray()) != "8,9,9,1") Console.WriteLine("FAIL!");


Console.WriteLine("Question 5b");
n1 = new LinkedList<int>();
n1.AddLast(6);
n1.AddLast(1);
n1.AddLast(7);
n2 = new LinkedList<int>();
n2.AddLast(2);
n2.AddLast(9);
n2.AddLast(5);
n3 = LinkedListQuestions.addNumbersReverseOrder(n1, n2);
if (String.Join(",", n3.ToArray()) != "9,1,2") Console.WriteLine("FAIL!");

n1 = new LinkedList<int>();
n1.AddLast(9);
n1.AddLast(9);
n1.AddLast(9);
n2 = new LinkedList<int>();
n2.AddLast(9);
n2.AddLast(9);
n2.AddLast(9);
n3 = LinkedListQuestions.addNumbersReverseOrder(n1, n2);
if (String.Join(",", n3.ToArray()) != "1,9,9,8") Console.WriteLine("FAIL!");

Console.WriteLine("Question 6");
testSLI = produceSinglyLinkedList();
if(LinkedListQuestions.findStartOfLoop(testSLI) != null) Console.WriteLine("FAIL!");

testSLI = produceSinglyLinkedListWithLoop();
if (LinkedListQuestions.findStartOfLoop(testSLI).Value != 100) Console.WriteLine("FAIL!");


Console.WriteLine("Question 7");
if(LinkedListQuestions.isPalindrome(produceLinkedList())) Console.WriteLine("FAIL!");
if (!LinkedListQuestions.isPalindrome(produceLinkedListOddPalindrome())) Console.WriteLine("FAIL!");
if (!LinkedListQuestions.isPalindrome(produceLinkedListEvenPalindrome())) Console.WriteLine("FAIL!");
if (!LinkedListQuestions.isPalindrome(produceLinkedListLengthNPalindrome(1))) Console.WriteLine("FAIL!");
if (!LinkedListQuestions.isPalindrome(produceLinkedListLengthNPalindrome(2))) Console.WriteLine("FAIL!");
if (!LinkedListQuestions.isPalindrome(produceLinkedListLengthNPalindrome(3))) Console.WriteLine("FAIL!");

// =================================================================================================================

Console.WriteLine("Chapter 3 - Stacks and Queues - Not Yet Implemented");

// =================================================================================================================

Console.WriteLine("Chapter 4 - Trees and Graphs - Not Yet Implemented");

// =================================================================================================================

Console.WriteLine("Chapter 5 - Bit Manipulation - Not Yet Implemented");

// =================================================================================================================

Console.WriteLine("Chapter 6 - Brain Teasers - Not Yet Implemented");

// =================================================================================================================

Console.WriteLine("Chapter 7 - Mathematics and Probability - Not Yet Implemented");

// =================================================================================================================

Console.WriteLine("Chapter 8 - Object-Oriented Design");

// TODO - Put simple CRUD app into seperate github repo
// TODO - Respond to open source feedback
// TODO - Chapter 8.


// =================================================================================================================


Console.WriteLine("Finished!");


static SinglyLinkedList<int> produceSinglyLinkedListWithLoop()
{
    var testSLI = new SinglyLinkedList<int>();
    testSLI.AddLast(1);
    testSLI.AddLast(10);
    testSLI.AddLast(7);
    testSLI.AddLast(30);
    testSLI.AddLast(100);
    var loopNode = testSLI.Last;
    testSLI.AddLast(6);
    testSLI.AddLast(7);
    testSLI.AddLast(8);
    testSLI.Last.Next = loopNode;
    return testSLI;
}

static SinglyLinkedList<int> produceSinglyLinkedList()
{
    var testSLI = new SinglyLinkedList<int>();
    testSLI.AddLast(1);
    testSLI.AddLast(10);
    testSLI.AddLast(7);
    testSLI.AddLast(30);
    testSLI.AddLast(100);
    testSLI.AddLast(6);
    testSLI.AddLast(7);
    testSLI.AddLast(8);
    return testSLI;
}

static LinkedList<int> produceLinkedList() {
    var testLI = new LinkedList<int>();
    testLI.AddLast(1);
    testLI.AddLast(10);
    testLI.AddLast(7);
    testLI.AddLast(30);
    testLI.AddLast(100);
    testLI.AddLast(6);
    testLI.AddLast(7);
    testLI.AddLast(8);
    return testLI;
}

static LinkedList<int> produceLinkedListOddPalindrome()
{
    var testLI = new LinkedList<int>();
    testLI.AddLast(1);
    testLI.AddLast(2);
    testLI.AddLast(3);
    testLI.AddLast(2);
    testLI.AddLast(1);
    return testLI;
}

static LinkedList<int> produceLinkedListLengthNPalindrome(int n)
{
    var testLI = new LinkedList<int>();
    for(var i = 0; i < n; i++)
    {
        testLI.AddLast(1);
    }
    return testLI;
}

static LinkedList<int> produceLinkedListEvenPalindrome()
{
    var testLI = new LinkedList<int>();
    testLI.AddLast(1);
    testLI.AddLast(2);
    testLI.AddLast(3);
    testLI.AddLast(3);
    testLI.AddLast(2);
    testLI.AddLast(1);
    return testLI;
}


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