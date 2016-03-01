namespace Clean.Code
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private enum AccountState { Active = 1, Inactive = 2, Blocked = 3, Erased = 4 }

        static void Main(string[] args)
        {
            Dictionary<int, string> registredAccountList = GetSampleData();

            var activeAccountsIds = GetActiveAccountsIds(registredAccountList);

            foreach (int activeAccountId in activeAccountsIds)
            {
                Console.WriteLine("Cuenta: {0} - Activa", activeAccountId);
            }
        }

        public static IEnumerable<int> GetActiveAccountsIds(Dictionary<int, string> registredAccountsList)
        {
            var activedAccountsList = new List<int>();

            foreach (var x in registredAccountsList)
            {
                if (x.Value == Enum.GetName(typeof(AccountState), AccountState.Active))
                {
                    activedAccountsList.Add(x.Key);
                }
            }

            return activedAccountsList;
        }

        private static Dictionary<int, string> GetSampleData()
        {
            Dictionary<int, string> accountListMocked = new Dictionary<int, string>();

            accountListMocked.Add(1, Enum.GetName(typeof(AccountState), AccountState.Blocked));
            accountListMocked.Add(2, Enum.GetName(typeof(AccountState), AccountState.Erased));
            accountListMocked.Add(3, Enum.GetName(typeof(AccountState), AccountState.Active));
            accountListMocked.Add(4, Enum.GetName(typeof(AccountState), AccountState.Inactive));
            accountListMocked.Add(5, Enum.GetName(typeof(AccountState), AccountState.Active));

            return accountListMocked;
        }
    }
}