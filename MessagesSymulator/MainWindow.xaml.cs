using MessagesSymulator.Controls;
using MessagesSymulator.ViewModel;
using Microsoft.Win32;
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
            SettingsPanel.Settings_MyAccount_Page.EditUsernameColorButton.Click += EditUsernameColorButton_Click;

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

        #region EditUsernameButton

        private void EditUsernameButton_Click(object sender, RoutedEventArgs e)
        {
            var enp = new EditTextPopup("Zmień swoją nazwę użytkownika",
                "Wprowadź nową nazwę użytkownika",
                "NAZWA UŻYTKOWNIKA");
            enp.Loaded += EditUsernamePopup_Loaded;
            enp.SaveButtonEvent += EditUsernamePopup_SaveButtonEvent;
            enp.BackgroundClickEvent += Popup_BackgroundClickEvent;
            MainPanel.Children.Add(enp);
        }

        private void EditUsernamePopup_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as EditTextPopup).NameTextBox.TextBoxSourceElement.Text = (DataContext as MainViewModel).ActiveUser.Username;
        }

        private void EditUsernamePopup_SaveButtonEvent(object sender, string e)
        {
            var enp = (sender as EditTextPopup);
            (DataContext as MainViewModel).ActiveUser.Username = enp.NameTextBox.TextBoxSourceElement.Text;
            MainPanel.Children.Remove(enp);
        }

        #endregion

        #region EditUsernameButton

        private void EditUsernameColorButton_Click(object sender, RoutedEventArgs e)
        {
            var enp = new EditTextPopup("Zmień kolor swojojej nazwy użytkownika",
                "Wprowadź nowy kolor nazwy użytkownika",
                "KOLOR NAZWY UŻYTKOWNIKA");
            enp.Loaded += EditUsernameColorPopup_Loaded;
            enp.SaveButtonEvent += EditUsernameColorPopup_SaveButtonEvent;
            enp.BackgroundClickEvent += Popup_BackgroundClickEvent;
            MainPanel.Children.Add(enp);
        }

        private void EditUsernameColorPopup_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as EditTextPopup).NameTextBox.TextBoxSourceElement.Text = (DataContext as MainViewModel).ActiveUser.UsernameColor;
        }

        private void EditUsernameColorPopup_SaveButtonEvent(object sender, string e)
        {
            var enp = (sender as EditTextPopup);
            (DataContext as MainViewModel).ActiveUser.UsernameColor = enp.NameTextBox.TextBoxSourceElement.Text;
            MainPanel.Children.Remove(enp);
        }

        #endregion

        #endregion EditUsernameButton

        #endregion MyAccount

        #endregion Settings

        private void Popup_BackgroundClickEvent(object sender, RoutedEventArgs e)
        {
            var enp = (sender as UIElement);
            MainPanel.Children.Remove(enp);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var mvm = (DataContext as MainViewModel);
            mvm.SaveUserData();
        }

        private void AddLinkButton_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            string filePath;
            if ((bool)fileDialog.ShowDialog())
            {
                filePath = fileDialog.FileName;
                var smwp = new SendMessageWithLinkComponentPopup((DataContext as MainViewModel).Message, filePath);
                smwp.BackgroundClickEvent += Popup_BackgroundClickEvent;
                smwp.SendButtonEvent += SendMessageWithLinkComponentPopup_SendButtonEvent;
                MainPanel.Children.Add(smwp);
            }
        }

        private void SendMessageWithLinkComponentPopup_SendButtonEvent(object sender, SendMessageWithLinkComponentPopupArgs e)
        {
            var smwlcp = (sender as SendMessageWithLinkComponentPopup);
            //(DataContext as MainViewModel).Message = e.MessageText;
            (DataContext as MainViewModel).MessageLink = e.Link;
            MainPanel.Children.Remove(smwlcp);
            (DataContext as MainViewModel).SendCommand.Execute(this);
        }
    }
}
