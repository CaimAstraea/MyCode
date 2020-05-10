/**
 * 编写一个程序，找到两个单链表相交的起始节点。
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        Dictionary<ListNode, bool> dic = new Dictionary<ListNode, bool>();
        ListNode tempA = headA;
        ListNode tempB = headB;
        while (tempA != null)
        {
            dic[tempA] = true;
            tempA = tempA.next;
        }
        while (tempB != null)
        {
            if (dic.ContainsKey(tempB))
            {
                return tempB;
            }
            tempB = tempB.next;
        }

        return null;
    }
}