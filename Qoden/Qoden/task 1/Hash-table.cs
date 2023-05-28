namespace Qoden.task_1
{
    class HashTable
    {
        public ListNode[] values;
        private int divider;
        public HashTable(int _divider)
        {
            values = new ListNode[_divider];
            divider = _divider;
        }

        public void Insert(int newValue)
        {
            var hashKey = newValue % divider;
            if (values[hashKey] == null) values[hashKey] = new ListNode();
            values[hashKey].Insert(newValue);
        }

        public void Print()
        {
            for (int i = 0; i < values.Length; i++)
            {
                Console.Write(i + ": ");

                if (values[i] != null)
                {
                    var nodeValues = values[i].Get();
                    Console.Write(nodeValues);
                }

                Console.WriteLine( );
            }
        }
    }
    class ListNode
    {
        int value;
        ListNode? next;
        public void Insert(int newValue)
        {
            if (value == default)
            {
                value = newValue;
                return;
            }

            if(next == null) 
            {
                next = new ListNode();
            }

            next.Insert(newValue);
        }

        public string Get() 
        {
            string values = value.ToString();
            if (next != null)
            {
                values += " " + next.Get();
            }
            return values;
        }
    }
}