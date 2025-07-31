// Problem: Add Two Numbers
// Tags: Linked List
// Difficulty: Medium
// Time: O(max(m, n))
// Space: O(1)

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        
        ListNode result = new();
        ListNode current = result;
        ListNode currentNode1 = l1;
        ListNode currentNode2 = l2;

        int carryOver = 0;

        while (currentNode1 != null || currentNode2 != null || carryOver != 0)
        {
            int val1 = currentNode1 != null ? currentNode1.val : 0;
            int val2 = currentNode2 != null ? currentNode2.val : 0;

            int sum = val1 + val2 + carryOver;
            carryOver = sum / 10;
            int digit = sum % 10;

            current.val = digit;

            if (currentNode1 != null) currentNode1 = currentNode1.next;
            if (currentNode2 != null) currentNode2 = currentNode2.next;

            if (currentNode1 != null || currentNode2 != null || carryOver != 0)
            {
                current.next = new ListNode();
                current = current.next;
            }
        }

        return result;
    }
}