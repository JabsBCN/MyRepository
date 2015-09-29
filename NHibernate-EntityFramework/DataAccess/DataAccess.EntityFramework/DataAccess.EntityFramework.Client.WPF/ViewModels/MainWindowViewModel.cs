using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Data;

using DataAccess.EntityFramework.Client.WPF.Common;
using DataAccess.EntityFramework.Client.WPF.DataHelpers;
using DataAccess.EntityFramework.Domain.ChartOfAccounts;

namespace DataAccess.EntityFramework.Client.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            var chartsOfAccounts = GetChartOfAccounts();
            ChartsOfAccountsView = new CollectionView(chartsOfAccounts);

            DeleteAccountCommand = new DelegateCommand(DeleteAccount, CanDeleteAccount);
        }

        private CollectionView _chartOfAccountsView;
        public CollectionView ChartsOfAccountsView
        {
            get { return _chartOfAccountsView; }
            set
            {
                _chartOfAccountsView = value;
                OnPropertyChanged("ChartsOfAccountsView");
            }
        }

        private Guid _chartOfAccountsSelected;
        public Guid ChartOfAccountsSelected
        {
            get { return _chartOfAccountsSelected; }
            set
            {
                _chartOfAccountsSelected = value;
                OnPropertyChanged("ChartOfAccountsSelected");

                List<Account> accounts = GetAccounts(_chartOfAccountsSelected);
                AccountsView = new CollectionView(accounts);
            }
        }

        private CollectionView _accountsView;
        public CollectionView AccountsView
        {
            get { return _accountsView; }
            set
            {
                _accountsView = value;
                OnPropertyChanged("AccountsView");
            }
        }

        private Account _accountSelected;
        public Account AccountSelected
        {
            get { return _accountSelected; }
            set
            {
                _accountSelected = value;
                OnPropertyChanged("AccountSelected");

                DeleteAccountCommand.RaiseCanExecuteChanged();
            }
        }

        #region Commands

        private DelegateCommand _deleteAccountCommand;
        public DelegateCommand DeleteAccountCommand
        {
            get
            {
                return _deleteAccountCommand; 
            }
            set
            {
                _deleteAccountCommand = value;
                OnPropertyChanged("DeleteAccountCommand");
            }
        }

        private void DeleteAccount(object parameter)
        {
            var chartOfAccounts = DataHelper.ChartsOfAccountsContext.ChartsOfAccounts.Find(ChartOfAccountsSelected);
            
            chartOfAccounts.DeleteAccount(AccountSelected.AccountId);
            
            DataHelper.ChartsOfAccountsContext.SaveChanges();
            ChartOfAccountsSelected = chartOfAccounts.ChartOfAccountsId;

        }

        private bool CanDeleteAccount(object parameter)
        {
            return AccountSelected != null;
        }
        #endregion

        #region private methods

        private List<ChartOfAccounts> GetChartOfAccounts()
        {
            List<ChartOfAccounts> chartsOfAccounts;

            chartsOfAccounts = DataHelper.ChartsOfAccountsContext.ChartsOfAccounts.OrderBy(r => r.Description).ToList();

            var chartOfAccounts = chartsOfAccounts.FirstOrDefault();
            if (chartOfAccounts != null)
            {
                ChartOfAccountsSelected = chartOfAccounts.ChartOfAccountsId;
            }

            return chartsOfAccounts;
        }

        private List<Account> GetAccounts(Guid chartOfAccountsId)
        {
            return DataHelper.ChartsOfAccountsContext.Accounts.Where(r => r.ChartOfAccountsId == chartOfAccountsId).ToList();
        }
        #endregion
    }
}
