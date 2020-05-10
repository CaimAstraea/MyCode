/*
将两个升序链表合并为一个新的升序链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。 
示例：
输入：1->2->4, 1->3->4
输出：1->1->2->3->4->4

 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public ListNode MergeTwoLists(ListNode Head, ListNode node)
    {
        if (Head == null)
        {
            return node;
        }
        else if (node == null)
        {
            return Head;
        }
        ListNode temp1 = Head;
        ListNode temp2 = node;
        ListNode temp3 = node.next;
        bool bInsert = false;
        while (temp2 != null)
        {
            if (temp2.val <= temp1.val)
            {
                temp2.next = temp1;
                Head = temp2;
                bInsert = true;
            }
            else if (temp2.val >= temp1.val && (temp1.next == null || temp2.val <= temp1.next.val))
            {
                temp2.next = temp1.next;
                temp1.next = temp2;
                bInsert = true;
            }
            temp1 = temp1.next;
            if (bInsert)
            {
                temp2 = temp3;
                if (temp3 != null)
                {
                    temp3 = temp3.next;
                }
                temp1 = Head;
                bInsert = false;
            }
        }
        return Head;
    }
}