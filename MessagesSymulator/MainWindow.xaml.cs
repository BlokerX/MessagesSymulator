﻿using MessagesSymulator.Controls;
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
            MainPanel.Visibility = Visibility.Hidden;
        }

        private void SettingsCloseButton_Click(object sender, RoutedEventArgs e)
        {
            MainPanel.Visibility = Visibility.Visible;
            SettingsPanel.Visibility = Visibility.Hidden;
        }

        #endregion

        #region MyAccount

        #region EditUsernameButton

        private void EditUsernameButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        #endregion EditUsernameButton

        #endregion MyAccount

        #endregion Settings

    }
}
