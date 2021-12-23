using System;
using System.Windows;

namespace WpfApp3
{
    internal class MainWindowVM
    {
        public partial class AnimalWindow : Window
        {
            public AnimalWindow()
            {
                InitializeComponent();
                DataContext = new ViewModel.AnimalViewModel();
            }

            private void InitializeComponent()
            {
                throw new NotImplementedException();
            }
        }
    }
}