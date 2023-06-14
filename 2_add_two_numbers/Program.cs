namespace _2_add_two_numbers
{
    internal class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
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

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode();
            var current = head;
            var carry = 0;
            while (l1 != null || l2 != null || carry != 0)
            {
                var lhs = l1?.val ?? 0;
                var rhs = l2?.val ?? 0;

                var temp = lhs + rhs + carry;
                current.next = new ListNode(temp % 10);
                current = current.next;
                carry = temp / 10;

                l1 = l1?.next;
                l2 = l2?.next;
            }

            return head.next;
        }

        static void Main(string[] args)
        {
            //[9,9,9,9,9,9,9]
            //[9,9,9,9]
            var list1 = new ListNode(new[] { 9, 9, 9, 9, 9, 9, 9 });
            list1.Print();
            Console.WriteLine("\r\n--------------");

            var list2 = new ListNode(new[] { 9, 9, 9, 9 });
            list2.Print();
            Console.WriteLine("\r\n--------------");
            //[8,9,9,9,0,0,0,1]
            AddTwoNumbers(list1, list2).Print();
        }
    }
}