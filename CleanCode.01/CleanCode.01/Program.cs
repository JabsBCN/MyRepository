namespace Clean.Code
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
        }

        public static IEnumerable<Guid> GetThen(Dictionary<Guid, int> list1)
        {
            var list2 = new List<Guid>();

            foreach (var x in list1)
            {
                if (x.Value == 4)
                {
                    list2.Add(x.Key);
                }
            }

            return list2;
        }
    }
}