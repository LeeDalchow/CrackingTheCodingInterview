using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview
{
    public static class LinkedListQuestions
    {

        /*
         * Note: The .NET implementation of LinkedList is a doubly linked list. For many of these problems a singly linked list
         * is assumed, however for simplicity, I have tried to use the .NET implementation where possible.
         * From Question 3 onwards, I implemented where appropiate a simple SinglyLinkedList class which was modified & expanded from a class I found on stackoverflow.
         */

        // 1. Write code to remove duplicates from an unsorted linked list.
        // Lee: I'll assume that the data type of the Linked List is an int.
        public static LinkedList<int> removeDuplicates(LinkedList<int> listToCheck)
        {
            var foundValues = new Dictionary<int, bool>(); // We use a Dictionary as key lookups are more efficient than ArrayLists. (Or Lists in C#)
            for (var curNode = listToCheck.First; curNode != null; curNode = curNode.Next) // For each node in the list
            {
                if (foundValues.ContainsKey(curNode.Value)) listToCheck.Remove(curNode);
                else foundValues.Add(curNode.Value, true);
            }

            return listToCheck;
        }

        // 1b. How would you solve this problem if a temporary buffer is not allowed?
        public static LinkedList<int> removeDuplicatesInPlace(LinkedList<int> listToCheck)
        {
            for (var curNode = listToCheck.First; curNode != null; curNode = curNode.Next) // For each node in the list
            {
                for (var nextNode = curNode.Next; nextNode != null; nextNode = nextNode.Next) // Seperate 'Runner' to head to the end of the list to find duplicates
                {
                    if (nextNode.Value == curNode.Value) // Duplicate found!
                    {
                        listToCheck.Remove(nextNode);
                        break;
                    }
                }
            }
            return listToCheck;
        }

        //2. Implement an algorithm to find the kth to last element of a singly linked list.
        // Lee: While I used .NET's doubly LinkedList implementation, only features of SinglyLinkedList were used.
        // Lee: Real world solution would use: listToCheck.Count - k, but in the sprit of the question, I'll do it manually!
        public static LinkedListNode<int> findKLastElement(LinkedList<int> listToCheck, int k)
        {
            // Bring runner 1 to element K
            LinkedListNode<int> run1Node;
            int countToK = 0;
            for (run1Node = listToCheck.First; countToK < k && run1Node != null; run1Node = run1Node.Next) countToK++;

            // Loop through LinkedList with runner 2 always K elements behind.
            var run2Node = listToCheck.First;
            while (run1Node.Next != null) // Loop until we find the end of the LinkedList
            {
                run2Node = run2Node.Next;
                run1Node = run1Node.Next;
            }
            return run2Node; // Runner 2 will be the K last element!
        }

        /*
         * 3. Implement an algorithm to delete a node in the middle of a singly linked list,
         * given only access to that node.
         * EXAMPLE
         * Input: The node c from the linked list a->b->c->d->e
         * Result: Nothing is returned but the new linked list looks like a-> b-> d-> e
         * 
         * Lee: This is the first class where I use a custom implementation of a LinkedList, as .NET's implementation is a doubly linked list.
         */
        public static void removeNodeFromList(ref SinglyLinkedList<int>.Node nodeToDelete)
        {
            var nextNode = nodeToDelete.Next;
            nodeToDelete.Value = nextNode.Value;
            nodeToDelete.Next = nextNode.Next;
        }

        // 4. Write code to partition a linked list around a value x, such that all nodes less than x come before all nodes greater than or equal to x.
        public static SinglyLinkedList<int> partitionLinkedList(SinglyLinkedList<int> listToCheck, int x)
        {
            var smallerElements = new SinglyLinkedList<int>();
            var largerElements = new SinglyLinkedList<int>();
            for (var curNode = listToCheck.First; curNode != null; curNode = curNode.Next)
            {
                if (curNode.Value < x) smallerElements.AddLast(curNode.Value);
                else largerElements.AddLast(curNode.Value);
            }

            // Join the 2 lists together
            smallerElements.Last.Next = largerElements.First;
            return smallerElements;
        }

        /* 
         * 5. You have two numbers represented by a linked list, where each node contains a single digit. The digits are stored in reverse order, such that the 1's digit
         * is at the head of the list. Write a function that adds the two numbers and returns the sum as a linked list.
         * 
         * EXAMPLE
         * Input: (7>1>6) + (5>9>2). That is, 617 + 295
         * Output: 2>1>9. That is, 912
         */
        public static LinkedList<int> addNumbers(LinkedList<int> n1, LinkedList<int> n2)
        {
            int num1 = 0;
            int num2 = 0;
            int growthFactor = 1; // Used to turn single digits into full numbers that can be added together. (ie. 1>2>3 = 1+20+300)
            var list1Node = n1.First;
            var list2Node = n2.First;

            do // calculate the input numbers.
            {
                if (list1Node != null) num1 += list1Node.Value * growthFactor;
                if (list2Node != null) num2 += list2Node.Value * growthFactor;
                growthFactor *= 10;
                list1Node = list1Node.Next;
                list2Node = list2Node.Next;
            } while (list1Node != null || list2Node != null);

            var newNumber = (num1 + num2).ToString().Reverse().ToArray(); // Do the calculation,convert to string & reverse as the logic needed is more readable than doing complex Maths.

            var result = new LinkedList<int>();
            foreach (char digit in newNumber)
            {
                result.AddLast((int)(digit - '0')); // convert char representation of a number into the actual int value
            }

            return result;
        }


        /*
         * 5b. Suppose the digits are stored in forward order. Repeat the above problem.
         * * EXAMPLE
         * Input: (6>1>7) + (2>9>5). That is, 617 + 295
         * Output: 9>1>2. That is, 912
         * 
         * Lee: I'll treat this like a singly linkedlist, I am not allowed to use .Prev
         */
        public static LinkedList<int> addNumbersReverseOrder(LinkedList<int> n1, LinkedList<int> n2)
        {
            int num1 = 0;
            int num2 = 0;
            int growthFactor1 = (int)Math.Pow(10, n1.Count - 1);
            int growthFactor2 = (int)Math.Pow(10, n2.Count - 1);
            var node1 = n1.First;
            var node2 = n2.First;

            do // calculate input numbers.
            {
                if (node1 != null) num1 += node1.Value * growthFactor1;
                if (node2 != null) num2 += node2.Value * growthFactor2;

                growthFactor1 /= 10;
                growthFactor2 /= 10;

                node1 = node1.Next;
                node2 = node2.Next;
            } while (node1 != null || node2 != null);

            double newNumber = num1 + num2; // Do the calculation. Leave as double so we have control over the rounding later.

            // Let's reuse growthFactor1 & calculate the start factor (We want to extract the highest digit)
            growthFactor1 = 1;
            while (newNumber / growthFactor1 >= 10)
            {
                growthFactor1 *= 10;
            };

            // Bring back into Linked List
            var result = new LinkedList<int>();
            do
            {
                int highestDigit = (int)Math.Floor(newNumber / growthFactor1); // Do the division & round down to 0dp
                result.AddLast(highestDigit);

                newNumber -= highestDigit * growthFactor1;
                growthFactor1 /= 10;
            } while (newNumber > 0);

            return result;
        }

        /*
         * 6. Given a circular linked list, implement an algorithm which returns the node at the start of the loop.
         * 
         * EXAMPLE:
         * 
         * A > B > C > D > E > C (Same C as earlier)
         * 
         * Output: C
         */

        public static SinglyLinkedList<int>.Node findStartOfLoop(SinglyLinkedList<int> toSearch)
        {
            var nodesFound = new List<SinglyLinkedList<int>.Node>();
            for (var curNode = toSearch.First; curNode != null; curNode = curNode.Next)
            {
                // Does node already exist?
                if (nodesFound.Contains(curNode)) { return curNode; } // Found the loop point!
                else nodesFound.Add(curNode);
            }

            return null; // If it get's here, there is no loop!
        }

        // 7. Implement a function to check if a linked list is a palindrome.
        // Lee: This one is far more elegant using a doubly linked list as below... You could do something similar with a Singly Linked List by reversing it and comparing it against the original.
        public static bool isPalindrome(LinkedList<int> toCheck)
        {
            var firstRunner = toCheck.First; // run from start
            var lastRunner = toCheck.Last; // run from end
            var listHalfLength = toCheck.Count / 2;

            var loopCounter = 0;
            do
            {
                loopCounter++;

                if (firstRunner.Value != lastRunner.Value) return false; // same so far, keep looping.
                else if(loopCounter > listHalfLength) return true; // We only need to check half of the loop

                firstRunner = firstRunner.Next;
                lastRunner = lastRunner.Previous;
            } while (true);
        }
    }


    // I got the class below from StackOverflow, and made some adjustments to it.
    // As the .NET implementation of a linkedlist is a doubly linkedlist and some of the algorithm challenges don't really work as a result.
    // I have implemented this, where appropiate.
    public class SinglyLinkedList<T>
    {
        public class Node
        {
            // link to next Node in list
            public Node Next = null;
            // value of this Node
            public T Value;
        }

        private Node root = null;

        public Node First { get { return root; } }

        public void AddLast(T data)
        {
            if (Count() > 0) Last.Next = new Node { Value = data };
            else root = new Node { Value = data };
        }

        public Node Last
        {
            get
            {
                Node curr = root;
                if (curr == null)
                    return null;
                while (curr.Next != null)
                    curr = curr.Next;
                return curr;
            }
        }

        public int Count()
        {
            int counter = 0;
            Node curNode = First;
            while (curNode != null)
            {
                counter++;
                curNode = curNode.Next;
            };
            return counter;
        }

        public T[] ToArray()
        {
            int size = Count();
            T[] newArr = new T[size];
            Node curNode = First;
            for(int i = 0; i < size; i++)
            {
                newArr[i] = curNode.Value;
                curNode = curNode.Next;
            }
            return newArr;
        }
    }
}
