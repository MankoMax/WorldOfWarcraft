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
using WorldofWarcraft.Managers;
using WorldofWarcraft.Repositories;
using WorldofWarcraft.Repository;

namespace WorldofWarcraft
{
    public partial class MainWindow : Window
    {
        private AccountManager _accountManager;
        private Account _loggedInAccount;

        public MainWindow()
        {
            InitializeComponent();
            _accountManager = new AccountManager();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            var login = textBoxLogin.Text.Trim();
            var password = PassBox.Password.Trim();
            var passwordToConfirm = PassBoxToConfirm.Password.Trim();

            if (login.Length == 0)
            {
                textBoxLogin.ToolTip = "Incorrect!";
                textBoxLogin.Background = Brushes.Red;
            }
            else if (password.Length == 0)
            {
                PassBox.ToolTip = "Incorrect!";
                PassBox.Background = Brushes.Red;
            }
            else if (passwordToConfirm != password)
            {
                PassBoxToConfirm.ToolTip = "Incorrect!";
                PassBoxToConfirm.Background = Brushes.Red;
            }
            else
            {
                var createdAccount = _accountManager.TryToCreateUserAccount(login, password, passwordToConfirm);

                if (createdAccount != null)
                {
                    _loggedInAccount = createdAccount;
                }

                textBoxLogin.Background = Brushes.Transparent;
                PassBox.Background = Brushes.Transparent;
                PassBoxToConfirm.Background = Brushes.Transparent;

                MessageBox.Show($"Account {login} Created Successfully!");

                var authenticationWindow = new AuthenticationWindow(_loggedInAccount);

                authenticationWindow.Show();

                Close();
            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            var authenticationWindow = new AuthenticationWindow(_loggedInAccount);

            authenticationWindow.Show();

            Close();
        }
    }
}
