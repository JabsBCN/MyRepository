using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using DataAccess.EntityFramework.Client.WPF.DataHelpers;

namespace DataAccess.EntityFramework.Client.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {

            this.Deactivated += (s, a) =>
            {
                DataHelper.Deactivate();
            };

        }

    }
}
