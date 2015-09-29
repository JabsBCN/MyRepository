﻿using System.Windows;

using DataAccess.EntityFramework.Client.WPF.ViewModels;

namespace DataAccess.EntityFramework.Client.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += (s, a) =>
            {
                this.DataContext = new MainWindowViewModel();
            };

        }
    }
}
