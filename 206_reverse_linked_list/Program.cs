namespace _206_reverse_linked_list
{
    internal class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode? next;
            public ListNode(int x = 0)
            {
                val = x;
                next = null;
            }
            public ListNode(IEnumerable<int> source)
            {
                var head = this;
                head.val = source.First();
                foreach (var item in source.Skip(1))
                {
                    head.next = new ListNode(item);
                    head = head.next;
                }
            }

            public void Print()
            {
                Console.Write(val + " ");
                next?.Print();
            }
        }

        public static ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            var stack = new Stack<ListNode>();
            while (head != null)
            {
                stack.Push(head);
                head = head.next;
            }

            var result = stack.Pop();
            var current = result;
            while (stack.Count > 0)
            {
                current.next = stack.Pop();
                current = current.next;
            }
            //unchain
            current.next = null;
            return result;
        }
        
        public static ListNode ReverseList2(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            //5->4->4->2->*
            //*<-5  4->4->2->*
            //5<-4  4->2->*

            ListNode prev = null;
            var current = head;
            while (current != null)
            {
                var tmp_next = current.next;
                current.next = prev;
                prev = current;
                current = tmp_next;
            }
            return prev;
        }

        static void Main(string[] args)
        {
            var list1 = new ListNode(new[] { 5, 4, 3, 2, 1, 0 });
            ReverseList(list1).Print();
            Console.WriteLine("\r\n--------------");
            list1 = new ListNode(new[] { 5, 4, 3, 2, 1, 0 });
            ReverseList2(list1).Print();
        }
    }
}