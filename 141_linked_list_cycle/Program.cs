namespace _141_linked_list_cycle
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


        public static bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return false;

            var set = new HashSet<ListNode>();
            var current = head;
            while (current != null)
            {
                if (!set.Add(current))
                    return true;
                current = current.next;
            }
            return false;
        }

        public static bool HasCycle2(ListNode head)
        {
            if (head == null || head.next == null)
                return false;

            var slow = head;
            var fast = head.next;
            //1-->2
            //^___|
            //
            //1-->2-->3
            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                    return false;
                
                slow = slow.next;
                fast = fast.next.next;
            }

            return true;
        }

        static void Main(string[] args)
        {
            var list2 = new ListNode(0);
            list2.next = new ListNode(1);
            list2.next.next = new ListNode(2);
            list2.next.next.next = new ListNode(5);

            Console.WriteLine(HasCycle(list2));
            Console.WriteLine(HasCycle2(list2));

            list2 = new ListNode(0);
            list2.next = new ListNode(1);
            list2.next.next = new ListNode(2);
            list2.next.next.next = new ListNode(5);
            list2.next.next.next.next = list2.next.next;

            Console.WriteLine(HasCycle(list2));
            Console.WriteLine(HasCycle2(list2));
        }
    }
}