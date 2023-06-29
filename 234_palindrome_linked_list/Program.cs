namespace _234_palindrome_linked_list
{
    internal class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }
        
        static ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            var current = head;
            while (current != null)
            {
                var nxt = current.next;
                current.next = prev;
                prev = current;
                current = nxt;
            }
            return prev;
        }

        public static bool IsPalindrome(ListNode head)
        {
            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            //1->2->(3)->2->1 : fast != null
            //1->2->3->(3)->2->1 : fast == null

            var rightHalf = ReverseList(fast == null ? slow : slow.next);

            slow = head;
            var rhCurr = rightHalf;
            while (rhCurr != null)
            {
                if (slow.val != rhCurr.val)
                    return false;
                slow = slow.next;
                rhCurr = rhCurr.next;
            }

            return true;
        }

        static void Main(string[] args)
        {
            var list = new ListNode(1);
            list.next = new ListNode(2);
            list.next.next = new ListNode(2);
            list.next.next.next = new ListNode(1);

            Console.WriteLine(IsPalindrome(list));
    
            list = new ListNode(1);
            list.next = new ListNode(2);

            Console.WriteLine(IsPalindrome(list));
        }
    }
}