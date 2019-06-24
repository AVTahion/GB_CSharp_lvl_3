using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Net;
using System.Net.Mail;
using MailSender.Components;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }

        private void OnCloseClick(object Sender, RoutedEventArgs e) => Close();

        private void TabController_OnLeftButtonClick(object Sender, EventArgs e)
        {
            if (!(Sender is TabController tab_controller)) return;

            if(tab_controller.IsLeftButtonVisible) MainTabControl.SelectedIndex--;

            tab_controller.IsLeftButtonVisible = MainTabControl.SelectedIndex > 0;
            tab_controller.IsRightButtonVisible = MainTabControl.SelectedIndex < MainTabControl.Items.Count;
        }

        private void TabController_OnRightButtonClick(object Sender, EventArgs e)
        {
            if (!(Sender is TabController tab_controller)) return;

            if (tab_controller.IsRightButtonVisible) MainTabControl.SelectedIndex++;

            tab_controller.IsLeftButtonVisible = MainTabControl.SelectedIndex > 0;
            tab_controller.IsRightButtonVisible = MainTabControl.SelectedIndex < MainTabControl.Items.Count;
        }

    }
}
