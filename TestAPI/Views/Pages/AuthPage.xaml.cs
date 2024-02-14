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
using TestAPI.Controllers;
using TestAPI.Models;

namespace TestAPI.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            LoginTextBox.Focus();
        }

        private void RegTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void RegTextBlockKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegTextBlockMouseLeftButtonDown(RegTextBlock, null);
            }
        }

        private void SignInButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = LoginTextBox.Text;
                {
                    string password = PasswordPasswordBox.Password;
                    if (login == String.Empty || password == String.Empty)
                    {
                        MessageBox.Show("Вы не ввели логин или пароль!");

                    }
                    else
                    {
                        List<Users> result = UsersController.GetUsers(login, password);
                        if (result != null)
                        {
                            App.CurrentUser = result.FirstOrDefault();
                            MessageBox.Show("Вы авторизованы");
                        }
                        else
                        {
                            MessageBox.Show("Пользователь отсутствует");
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
