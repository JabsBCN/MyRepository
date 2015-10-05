using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using MongoDB.Bson;

namespace DataAccess.Client.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += (s, a) =>
            {
                this.DataContext = new MainWindowViewModel();

                CollectionViewSource itemCollectionViewSource;
                itemCollectionViewSource = (CollectionViewSource)(FindResource("ItemCollectionViewSource"));
                itemCollectionViewSource.Source = this.mainWindowViewModel.ArtistsView;
                var documents = itemCollectionViewSource.ToBsonDocument();
            };
        }
    }
}
