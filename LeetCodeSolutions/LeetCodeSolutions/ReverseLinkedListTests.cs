using System;
using Xunit;

namespace LeetCodeSolutions
{
    /* https://leetcode.com/problems/reverse-linked-list/
    206. Reverse Linked List
    Easy
    Reverse a singly linked list.

    Example:

    Input: 1->2->3->4->5->NULL
    Output: 5->4->3->2->1->NULL
    Follow up:

    A linked list can be reversed either iteratively or recursively. Could you implement both?
    */

    public class ReverseLinkedListTests
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public class RecursivelySolution
        {
            public ListNode ReverseList(ListNode head)
            {
                return Reverse(head, null);
            }

            private ListNode Reverse(ListNode currentNode, ListNode previousNode)
            {
                if (currentNode == null)
                {
                    return previousNode;
                }

                var next = currentNode.next;
                currentNode.next = previousNode;
                return Reverse(next, currentNode);
            }
        }

        public class IterativelySolution
        {
            public ListNode ReverseList(ListNode head)
            {
                ListNode prevNode = null;
                while (head != null)
                {
                    var next = head.next;
                    head.next = prevNode;
                    prevNode = head;
                    head = next;
                }

                return prevNode;
            }
        }


        [Fact]
        public void ExecuteRecursively()
        {
            var solution = new RecursivelySolution();
            ListNode head = new ListNode
            {
                val = 1,
                next = new ListNode
                {
                    val = 2,
                    next = new ListNode
                    {
                        val = 3,
                        next = new ListNode
                        {
                            val = 4
                        }
                    }
                }
            };

            var reversed = solution.ReverseList(head);
        }


        [Fact]
        public void ExecuteIteratively()
        {
            var solution = new IterativelySolution();
            ListNode head = new ListNode
            {
                val = 1,
                next = new ListNode
                {
                    val = 2,
                    next = new ListNode
                    {
                        val = 3,
                        next = new ListNode
                        {
                            val = 4
                        }
                    }
                }
            };

            var reversed = solution.ReverseList(head);
        }
    }
}
