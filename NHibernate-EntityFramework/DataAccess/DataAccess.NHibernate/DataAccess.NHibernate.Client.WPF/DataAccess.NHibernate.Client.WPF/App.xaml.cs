using System.Windows;

using DataAccess.NHibernate.Client.WPF.DataHelpers;

namespace DataAccess.NHibernate.Client.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            this.Deactivated += (s, a) => AppSessionHelper.Deactivate();
        }

    }
}
