using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview
{
    public static class LinkedListQuestions
    {

        // Note: The .NET implementation of LinkedList is a doubly linked list. For many of these problems a singly linked list
        // would be sufficient. There's probably a library available on NuGet for singly linked lists, but for simplicity,
        // I'll use the doubly linked list for all problems in this class.

        // 1. Write code to remove duplicates from an unsorted linked list.
        // Lee: I'll assume that the data type of the Linked List is an int.
        public static LinkedList<int> removeDuplicates(LinkedList<int> listToCheck)
        {
            var foundValues = new Dictionary<int, bool>();
            for (var curNode = listToCheck.First; curNode != null; curNode = curNode.Next)
            {
                if (foundValues.ContainsKey(curNode.Value))
                {
                    listToCheck.Remove(curNode);
                } else {                 
                    foundValues.Add(curNode.Value, true);
                }
            }

            return listToCheck;
        }

        // 1b. How would you solve this problem if a temporary buffer is not allowed?
        public static LinkedList<int> removeDuplicatesInPlace(LinkedList<int> listToCheck)
        {
            for(var curNode = listToCheck.First; curNode != null; curNode = curNode.Next)
            {
                for(var prevNode = curNode.Previous; prevNode != null; prevNode = prevNode.Previous)
                {
                    if(prevNode.Value == curNode.Value) // Duplicate found!
                    {
                        listToCheck.Remove(curNode);
                        break;
                    }
                }
            }
            return listToCheck;
        }

        //2. Implement an algorithm to find the kth to last element of a singly linked list.
        public static LinkedListNode<int> findKLastElement(LinkedList<int> listToCheck, int k)
        {
            // Real world solution would use: listToCheck.Count - k
            // I assume 
            
            // Bring first runner to element K
            int countToK = 0;
            LinkedListNode<int> curNode;
            for (curNode = listToCheck.First; countToK < k && curNode != null; curNode = curNode.Next) countToK++;

            // Loop through LinkedList with a runner always K elements behind.
            var runnerNode = listToCheck.First;
            while(curNode.Next != null) // Loop until we find the end of the LinkedList
            {
                runnerNode = runnerNode.Next;
                curNode = curNode.Next;
            }
            return runnerNode;
        }

        /*
         * 3. Implement an algorithm to delete a node in the middle of a singly linked list,
         * given only access to that node.
         * EXAMPLE
         * Input: The node c from the linked list a->b->c->d->e
         * Result: Nothing is returned but the new linked list looks like a-> b-> d-> e
         */
        public static void removeNodeFromList(ref LinkedListNode<int> nodeToDelete)
        {
            /*
             * This does not appear to be possible within .NET's implementation of LinkedLists because LinkedListNode.Next is a readonly property.
             * So instead, I will leave the lines not supported by .NET as commented out to avoid compile errors.
             * I will not include this method within Program.cs
             * 
             * Update: It seems I can use node.List to get the original linkedlist and solve this problem that way, but I feel that is not in the
             * sprit of the question.
             */

            var nextNode = nodeToDelete.Next;
            nodeToDelete.Value = nextNode.Value;
            //nodeToDelete.Next = nextNode.Next; // This will error because .Next is readonly in .NET
        }
        
        // 4. Write code to partition a linked list around a value x, such that all nodes less than x come before all nodes greater than or equal to x.
        // Note: This is the first class where I use a custom implementation of a LinkedList, as .NET's implementation is a doubly linked list.
        public static SinglyLinkedList<int> partitionLinkedList(SinglyLinkedList<int> listToCheck, int x)
        {
            var newListSmall = new SinglyLinkedList<int>();
            var newListBigger = new SinglyLinkedList<int>();
            for (var curNode = listToCheck.First; curNode != null; curNode = curNode.Next)
            {
                if(curNode.Value < x) newListSmall.AddLast(curNode.Value);
                else newListBigger.AddLast(curNode.Value);
            }

            // Join the 2 lists together
            newListSmall.Last.Next = newListBigger.First;
            return newListSmall;
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
            int growthFactor = 1;
            var node1 = n1.First;
            var node2 = n2.First;

            do // calculate input numbers.
            {
                if(node1 != null) num1 += node1.Value * growthFactor;
                if(node2 != null) num2 += node2.Value * growthFactor;
                growthFactor *= 10;
                node1 = node1.Next;
                node2 = node2.Next;
            } while (node1 != null || node2 != null);

            double newNumber = num1 + num2; // Do the calculation. Leave as double so we have control over the rounding later.

            // Bring back into Linked List
            var result = new LinkedList<int>();
            do
            {
                growthFactor /= 10;
                int digitAdded = (int)Math.Floor(newNumber / growthFactor); // Do the division, round down & convert back to int.
                result.AddLast(digitAdded); 
                newNumber -= digitAdded * growthFactor;
            } while (growthFactor > 1);

            return result;
        }


        // 5b. Suppose the digits are stored in forward order. Repeat the above problem.
        //Lee: Basically the same, but go backwards via the linkedlist since it's doubly linked.
        // Using a singly linkedlist would require calculating the maximum growthFactor and then /10 each node to extract the number.
        // I've copy-pasted the below since it's a new question but honestly you could probably build a single method to do both 5 & 5b depending on a parameter.
        public static LinkedList<int> addNumbersReverseOrder(LinkedList<int> n1, LinkedList<int> n2)
        {
            int num1 = 0;
            int num2 = 0;
            int growthFactor = 1;
            var node1 = n1.Last;
            var node2 = n2.Last;

            do // calculate input numbers.
            {
                if (node1 != null) num1 += node1.Value * growthFactor;
                if (node2 != null) num2 += node2.Value * growthFactor;
                growthFactor *= 10;
                node1 = node1.Previous;
                node2 = node2.Previous;
            } while (node1 != null || node2 != null);

            double newNumber = num1 + num2; // Do the calculation. Leave as double so we have control over the rounding later.

            // Bring back into Linked List
            var result = new LinkedList<int>();
            do
            {
                growthFactor /= 10;
                int digitAdded = (int)Math.Floor(newNumber / growthFactor); // Do the division, round down & convert back to int.
                result.AddFirst(digitAdded);
                newNumber -= digitAdded * growthFactor;
            } while (growthFactor > 1);

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
            // 2 possible ways to do this:
            // 1) Create a seperate data structure to store the Nodes seen so far (ByRef)
            // 2) Have two runners, a slow pointer & a fast pointer. The slow pointer moves at 1 pace & the fast pointer moves at 2 paces.
            // However, option 2 seems to be overly complicated as there are several extra parts which need to be considered. I will implement option 1.

            var nodesFound = new List<SinglyLinkedList<int>.Node>();
            for(var curNode = toSearch.First; curNode != null; curNode = curNode.Next)
            {
                // Does node already exist?
                if(nodesFound.Contains(curNode)) { return curNode; } // Found the loop point!
                else nodesFound.Add(curNode);
            }

            return null; // If it get's here, there is no loop!
        }

        //7. Implement a function to check if a linked list is a palindrome.

    }



    // I got the class below from StackOverflow, and made some adjustments to it.
    // As the .NET implementation of a linkedlist is a doubly linkedlist and some of the algorithm challenges don't really work as a result.
    // I have implemented this, where appropiate from Question 4 onwards.
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
