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
using WorldofWarcraft.Repository;

namespace WorldofWarcraft
{
    public partial class AccountWindow : Window
    {
        private AuthenticationWindow _authenticationWindow;
        public Account LoggedInAccount { get; set; }

        public AccountWindow(Account loggedInAccount)
        {
            InitializeComponent();

            LoggedInAccount = loggedInAccount;

            _authenticationWindow = new AuthenticationWindow(loggedInAccount);

            var characterList = LoggedInAccount.Characters;

            listOfCharacters.ItemsSource = characterList;

            var userName = loggedInAccount.UserName;
        }
    }
}
