using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using WorldofWarcraft.Managers;
using WorldofWarcraft.Repositories;

namespace WorldofWarcraft
{
    public partial class RegPage : Page
    {
        private AccountManager _accountManager;
        private Account _loggedInAccount;

        public RegPage()
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

                NavigationService.Navigate(new AuthPage(_loggedInAccount));
            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage(_loggedInAccount));
        }
    }
}
