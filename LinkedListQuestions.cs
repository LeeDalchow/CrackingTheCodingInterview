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
            var newList = new LinkedList<int>();
            foreach(var node in listToCheck)
            {
                if (!foundValues.ContainsKey(node))
                {
                    foundValues.Add(node, true);
                    newList.AddLast(node);
                }
            }

            return newList;
        }

        // 1b. How would you solve this problem if a temporary buffer is not allowed?
        // Loop backwards through the LI or each element?
        // TODO: Cleanup Program.cs for last method.
    }
}
