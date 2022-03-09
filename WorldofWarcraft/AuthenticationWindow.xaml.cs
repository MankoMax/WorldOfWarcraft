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
using System.Windows.Shapes;
using WorldofWarcraft.Managers;
using WorldofWarcraft.Repositories;

namespace WorldofWarcraft
{
    public partial class AuthenticationWindow : Window
    {
        private AccountManager _accountManager;
        private Account _loggedInAccount;

        public Account LoggedInAccount { get; set; }

        public AuthenticationWindow(Account loggedInAccount)
        {
            InitializeComponent();
            _accountManager = new AccountManager();
            LoggedInAccount = loggedInAccount;
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            var login = textBoxLogin.Text.Trim();
            var password = PassBox.Password.Trim();

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
            else
            {
                _accountManager.TryToLogin(login, password, out _loggedInAccount);

                if (_loggedInAccount != null)
                {
                    textBoxLogin.Background = Brushes.Transparent;
                    PassBox.Background = Brushes.Transparent;

                    MessageBox.Show($"Account {login} is Logged In Successfully!");

                    var accountWindow = new AccountWindow(_loggedInAccount);

                    accountWindow.Show();

                    Close();
                }
                else
                {
                    MessageBox.Show("Incorrect!");
                }
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();

            mainWindow.Show();

            Close();
        }
    }
}
