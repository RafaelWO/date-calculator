using System;
using System.Windows;
using DateCalculator.ViewModels;

namespace DateCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel mainViewModel;

        public MainWindow(MainViewModel mainVm)
        {
            InitializeComponent();
            DataContext = mainVm;
            mainViewModel = mainVm;
        }

        private void Cmd_AddAnniversary_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NewAnniversary.Text))
            {
                e.CanExecute = true;
            }
        }

        private void Cmd_AddAnniversary_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            mainViewModel?.AddAnniversary(NewAnniversary.Text.Trim());
        }

        private void Cmd_DeleteAnniversary_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            if (mainViewModel?.SelectedAnniversary != null)
            {
                e.CanExecute = true;
            }
        }

        private void Cmd_DeleteAnniversary_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (!mainViewModel?.DeleteAnniversary() ?? false)
            {
                MessageBox.Show("Error");
            }
        }

        private void Cmd_CreateCalenderEvent_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            if (mainViewModel?.SelectedAnniversary == null) return;
            if (mainViewModel?.SelectedAnniversary.Date < DateTime.Now) return;

            e.CanExecute = true;
        }

        private void Cmd_CreateCalenderEvent_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

        }
    }
}
