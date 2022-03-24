using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using WorldofWarcraft.Managers;
using WorldofWarcraft.Repositories;

namespace WorldofWarcraft
{
    public partial class AuthPage : Page
    {
        private AccountManager _accountManager;
        private Account _loggedInAccount;

        public Account LoggedInAccount { get; set; }

        public AuthPage(Account loggedInAccount)
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

                    NavigationService.Navigate(new AccountPage(_loggedInAccount));
                }
                else
                {
                    MessageBox.Show("Incorrect!");
                }
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }
    }
}
