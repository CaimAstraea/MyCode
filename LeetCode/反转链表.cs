/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        if (head == null)
        {
            return head;
        }
        ListNode node = head;
        ListNode node2 = node.next;
        ListNode node3 = node2 != null ? node2.next : null;
        node.next = null;
        while (node3 != null || node2 != null)
        {
            node2.next = node;
            node = node2;

            node2 = node3 != null ? node3.next : null;
            if (node3 != null)
            {
                node3.next = node;
                node = node3;
                node3 = node2 != null ? node2.next : null;
            }
        }
        return node3 != null ? node3 : (node2 != null ? node2 : node);
    }
}