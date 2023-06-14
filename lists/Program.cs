namespace lists
{
    internal class Program
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

            public void Print()
            {
                Console.Write(val + " ");
                next?.Print();
            }
        }

        public static ListNode Merge2Lists(ListNode l, ListNode r)
        {
            ListNode head = new ListNode();
            var current = head;
            while (l != null || r != null)
            {
                current.next = new ListNode();
                current = current.next;

                if (l == null && r != null)
                {
                    current.val = r.val;
                    r = r.next;
                }
                else if (r == null && l != null)
                {
                    current.val = l.val;
                    l = l.next;
                }
                else
                {
                    if (r.val < l.val)
                    {
                        current.val = r.val;
                        r = r.next;
                    }
                    else
                    {
                        current.val = l.val;
                        l = l.next;
                    }
                }
            }
            return head.next;
        }

        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;

            if (lists.Length == 1)
                return lists[0];

            ListNode result = lists[0];
            for (int i = 1; i < lists.Length; i++)
            {
                result = Merge2Lists(result, lists[i]);
            }
            //0 1 2 3 4 5
            //0 * 2 * 4 *
            //0 * * * 4 *
            //0 * * * * *
            var totalLen = lists.Length;
            var step = 1;
            while (step < totalLen)
            {
                for (int i = 0; i < totalLen - step; i += 2 * step)
                {
                    lists[i] = Merge2Lists(lists[i], lists[i + step]);
                }
                step *= 2;
            }

            return result;
        }


        static void Main(string[] args)
        {
            var list1 = new ListNode(1);
            list1.next = new ListNode(3);

            var list2 = new ListNode(0);
            list2.next = new ListNode(1);
            list2.next.next = new ListNode(2);
            list2.next.next.next = new ListNode(5);

            list1.Print();
            Console.WriteLine("\r\n----------");
            list2.Print();
            Console.WriteLine("\r\n----------");
            Merge2Lists(list1, list2).Print();
            Console.WriteLine("\r\n----------");
            MergeKLists(new[] { list1, list2 }).Print();
        }
    }
}