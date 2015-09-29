using System.Collections.Generic;

using DataAccess.EntityFramework.Domain.ChartOfAccounts;

namespace DataAccess.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.EntityFramework.ChartsOfAccounts.ChartsOfAccountsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.EntityFramework.ChartsOfAccounts.ChartsOfAccountsContext context)
        {

            GetChartsOfAccounts().ForEach(chartOfAccounts =>
            {
                context.ChartsOfAccounts.AddOrUpdate(r => r.ChartOfAccountsId, chartOfAccounts);
                GetAccounts(chartOfAccounts.ChartOfAccountsId).ForEach(account => context.Accounts.AddOrUpdate(r => r.AccountId, account));
            });
            context.SaveChanges();

        }

        private List<ChartOfAccounts> GetChartsOfAccounts()
        {
            return new List<ChartOfAccounts>()
            {
                GetChartOfAccounts(new Guid("11B7DF8F-BF55-4B31-B89F-F834DD9F7BEE"), "Chart of accounts 1"),
                GetChartOfAccounts(new Guid("B6DD75A3-4D8A-4A1F-8564-D6BD6851C260"), "Chart of accounts 2"),
                GetChartOfAccounts(new Guid("9C20FCB1-B017-4E2A-A1C7-4BAA354D1C4D"), "Chart of accounts 3"),
                GetChartOfAccounts(new Guid("03972192-A30B-45B2-A4EC-8F3E49B37C6C"), "Chart of accounts 4"),
                GetChartOfAccounts(new Guid("3D0DAD0A-C361-446E-B80A-A68D51A8727A"), "Chart of accounts 5")
            };
        }

        private ChartOfAccounts GetChartOfAccounts(Guid chartOfAccountsId, string description)
        {
            return new ChartOfAccounts
            {
                ChartOfAccountsId = chartOfAccountsId,
                Description = description
            };
        }

        private List<Account> GetAccounts(Guid chartOfAccountsId)
        {

            var accountsList = new List<Account>()
            {

                // Accounts for chart of accounts 1
                new Account()
                {
                    AccountId = new Guid("40E3B5CB-B7CB-4788-9DCF-C64E233284AB"),
                    ChartOfAccountsId = new Guid("11B7DF8F-BF55-4B31-B89F-F834DD9F7BEE"),
                    AccountNumber = "10001",
                    Description = "Account 1"
                },
                new Account()
                {
                    AccountId = new Guid("6DC8E026-7892-44A8-88F1-8404E3B50530"),
                    ChartOfAccountsId = new Guid("11B7DF8F-BF55-4B31-B89F-F834DD9F7BEE"),
                    AccountNumber = "10002",
                    Description = "Account 2"
                },
                new Account()
                {
                    AccountId = new Guid("20837D7E-BC72-40DB-A159-DA2C3CEBCF86"),
                    ChartOfAccountsId = new Guid("11B7DF8F-BF55-4B31-B89F-F834DD9F7BEE"),
                    AccountNumber = "10003",
                    Description = "Account 3"
                },
                new Account()
                {
                    AccountId = new Guid("8C218120-F667-48D9-97C9-70749036F915"),
                    ChartOfAccountsId = new Guid("11B7DF8F-BF55-4B31-B89F-F834DD9F7BEE"),
                    AccountNumber = "10004",
                    Description = "Account 4"
                },
                new Account()
                {
                    AccountId = new Guid("EB087FF3-582C-4568-B2BF-593809B2FCD1"),
                    ChartOfAccountsId = new Guid("11B7DF8F-BF55-4B31-B89F-F834DD9F7BEE"),
                    AccountNumber = "10005",
                    Description = "Account 5"
                },

                // Accounts for chart of accounts 2
                new Account()
                {
                    AccountId = new Guid("F89464D1-EE0B-4CC2-A16E-5F9288C11E6D"),
                    ChartOfAccountsId = new Guid("B6DD75A3-4D8A-4A1F-8564-D6BD6851C260"),
                    AccountNumber = "10001",
                    Description = "Account 1"
                },
                new Account()
                {
                    AccountId = new Guid("099C9021-5C93-4B39-96DF-8DCA9E8FCFB8"),
                    ChartOfAccountsId = new Guid("B6DD75A3-4D8A-4A1F-8564-D6BD6851C260"),
                    AccountNumber = "10002",
                    Description = "Account 2"
                },
                new Account()
                {
                    AccountId = new Guid("7DBF12DE-3B04-460A-8E59-99FBE78C16A6"),
                    ChartOfAccountsId = new Guid("B6DD75A3-4D8A-4A1F-8564-D6BD6851C260"),
                    AccountNumber = "10003",
                    Description = "Account 3"
                },

                // Accounts for chart of accounts 3
                new Account()
                {
                    AccountId = new Guid("88145F59-7641-476B-A877-9713F20B36B4"),
                    ChartOfAccountsId = new Guid("9C20FCB1-B017-4E2A-A1C7-4BAA354D1C4D"),
                    AccountNumber = "10001",
                    Description = "Account 1"
                },
                new Account()
                {
                    AccountId = new Guid("AEB61176-FB7E-4B41-A5B1-707CE8602918"),
                    ChartOfAccountsId = new Guid("9C20FCB1-B017-4E2A-A1C7-4BAA354D1C4D"),
                    AccountNumber = "10002",
                    Description = "Account 2"
                },
                new Account()
                {
                    AccountId = new Guid("5008A8DD-A1DE-4E2B-81CC-212A566C61AC"),
                    ChartOfAccountsId = new Guid("9C20FCB1-B017-4E2A-A1C7-4BAA354D1C4D"),
                    AccountNumber = "10003",
                    Description = "Account 3"
                },
                new Account()
                {
                    AccountId = new Guid("9467EBFB-ECBF-429F-B409-CFF2C2C6D3A7"),
                    ChartOfAccountsId = new Guid("9C20FCB1-B017-4E2A-A1C7-4BAA354D1C4D"),
                    AccountNumber = "10004",
                    Description = "Account 4"
                },
                new Account()
                {
                    AccountId = new Guid("3B1D4420-F9AE-4551-A7A0-D0C8B7CDB26C"),
                    ChartOfAccountsId = new Guid("9C20FCB1-B017-4E2A-A1C7-4BAA354D1C4D"),
                    AccountNumber = "10005",
                    Description = "Account 5"
                },
                new Account()
                {
                    AccountId = new Guid("CB90FE90-0FEA-4AA2-9C93-C22355543C50"),
                    ChartOfAccountsId = new Guid("9C20FCB1-B017-4E2A-A1C7-4BAA354D1C4D"),
                    AccountNumber = "10006",
                    Description = "Account 6"
                }

            };

            return accountsList.Where(r => r.ChartOfAccountsId == chartOfAccountsId).ToList();

        }

    }
}
