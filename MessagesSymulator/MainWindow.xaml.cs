using MessagesSymulator.Controls;
using MessagesSymulator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MessagesSymulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region SettingsPanelInitialize

            SettingsPanel.BackToTheMenuButton.Click += SettingsCloseButton_Click;
            SettingsPanel.Settings_MyAccount_Page.EditUsernameButton.Click += EditUsernameButton_Click;

            #endregion
        }

        #region BorderApp

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void WindowStateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowStyle = WindowStyle.SingleBorderWindow;
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
                Application.Current.MainWindow.WindowStyle = WindowStyle.None;
            }
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion

        #region Settings

        #region Settings Open/Close

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsPanel.Visibility = Visibility.Visible;
            MainGridSite.Visibility = Visibility.Hidden;
        }

        private void SettingsCloseButton_Click(object sender, RoutedEventArgs e)
        {
            MainGridSite.Visibility = Visibility.Visible;
            SettingsPanel.Visibility = Visibility.Hidden;
        }

        #endregion

        #region MyAccount

        #region EditButtons

        private void EditUsernameButton_Click(object sender, RoutedEventArgs e)
        {
            var enp = new EditNamePopup("Zmień swoją nazwę użytkownika", 
                "Wprowadź nową nazwę użytkownika", 
                "NAZWA UŻYTKOWNIKA");
            enp.Loaded += EditUsernamePopup_Loaded;
            enp.SaveButtonEvent += EditUsernamePopup_SaveButtonEvent;
            enp.BackgroundClickEvent += EditPopup_BackgroundClickEvent;
            MainPanel.Children.Add(enp);
        }

        private void EditUsernamePopup_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as EditNamePopup).NameTextBox.TextBoxSourceElement.Text = (DataContext as MainViewModel).ActiveUser.Username;
        }

        private void EditUsernamePopup_SaveButtonEvent(object sender, string e)
        {
            var enp = (sender as EditNamePopup);
            (DataContext as MainViewModel).ActiveUser.Username = enp.NameTextBox.TextBoxSourceElement.Text;
            MainPanel.Children.Remove(enp);
        }

        private void EditPopup_BackgroundClickEvent(object sender, RoutedEventArgs e)
        {
            var enp = (sender as EditNamePopup); 
            MainPanel.Children.Remove(enp);
        }

        #endregion EditUsernameButton

        #endregion MyAccount

        #endregion Settings

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var mvm = (DataContext as MainViewModel);
            mvm.SaveUserData();
        }
    }
}
