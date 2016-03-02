namespace Clean.Code
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private enum AccountState { Active = 1, Inactive = 2, Blocked = 3, Erased = 4 }

        static void Main(string[] args)
        {
            Dictionary<int, string> registredAccounts = GetSampleData();

            IEnumerable<int> activeAccountsIds = GetActiveAccountsIds(registredAccounts);

            foreach (int activeAccountId in activeAccountsIds)
            {
                Console.WriteLine("Cuenta: {0} - Activa", activeAccountId);
            }
        }

        public static IEnumerable<int> GetActiveAccountsIds(Dictionary<int, string> registeredAccounts)
        {
            var activedAccountsList = new List<int>();

            foreach (var registeredAccount in registeredAccounts)
            {
                if (registeredAccount.Value == Enum.GetName(typeof(AccountState), AccountState.Active))
                {
                    activedAccountsList.Add(registeredAccount.Key);
                }
            }

            return activedAccountsList;
        }

        private static Dictionary<int, string> GetSampleData()
        {
            Dictionary<int, string> sampleAccountsDictionary = new Dictionary<int, string>
            {
                { 1, Enum.GetName(typeof(AccountState), AccountState.Blocked) },
                { 2, Enum.GetName(typeof(AccountState), AccountState.Erased) },
                { 3, Enum.GetName(typeof(AccountState), AccountState.Active) },
                { 4, Enum.GetName(typeof(AccountState), AccountState.Inactive) },
                { 5, Enum.GetName(typeof(AccountState), AccountState.Active) }
            };

            return sampleAccountsDictionary;
        }
    }
}