using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using DataAccess.NHibernate.Client.WPF.Common;
using DataAccess.NHibernate.Client.WPF.DataHelpers;
using DataAccess.NHibernate.Domain.ChartsOfAccounts;
using NHibernate.Criterion;

namespace DataAccess.NHibernate.Client.WPF.ViewModels
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
            using (var transaction = AppSessionHelper.Session.BeginTransaction())
            {
                var chartOfAccounts = AppSessionHelper.Session.Get<ChartOfAccounts>(ChartOfAccountsSelected);
                chartOfAccounts.DeleteAccount(AccountSelected.AccountId);
                AppSessionHelper.Session.SaveOrUpdate(chartOfAccounts);
                transaction.Commit();

                ChartOfAccountsSelected = chartOfAccounts.ChartOfAccountsId;

            }
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

            chartsOfAccounts = AppSessionHelper.Session.CreateCriteria<ChartOfAccounts>().List<ChartOfAccounts>().ToList();

            var chartOfAccounts = chartsOfAccounts.FirstOrDefault();
            if (chartOfAccounts != null)
            {
                ChartOfAccountsSelected = chartOfAccounts.ChartOfAccountsId;
            }

            return chartsOfAccounts;
        }

        private List<Account> GetAccounts(Guid chartOfAccountsId)
        {
            var criteria = AppSessionHelper.Session.CreateCriteria<Account>()
                .Add(Restrictions.Eq("ChartOfAccountsId", chartOfAccountsId))
                .List<Account>();

            return criteria.ToList();
        }
        #endregion
    }
}
