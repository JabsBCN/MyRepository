namespace Clean.Code
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> list1 = GetSampleData();

            var list2 = GetThen(list1);

            foreach (int item in list2)
            {
                Console.WriteLine("Cuenta: {0} - Activa", item);
            }
        }

        public static IEnumerable<int> GetThen(Dictionary<int, string> list1)
        {
            var list2 = new List<int>();

            foreach (var x in list1)
            {
                if (x.Value == "1")
                {
                    list2.Add(x.Key);
                }
            }

            return list2;
        }

        private static Dictionary<int, string> GetSampleData()
        {
            Dictionary<int, string> list = new Dictionary<int, string>
            {
                { 1, "3" },
                { 2, "4" },
                { 3, "1" },
                { 4, "2" },
                { 5, "1" }
            };

            return list;
        }
    }
}