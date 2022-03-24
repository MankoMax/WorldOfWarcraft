using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using WorldofWarcraft.Repositories;
using WorldofWarcraft.Repository;

namespace WorldofWarcraft
{
    public partial class AccountPage : Page
    {
        private AuthPage _authPage;

        private CharacterRepository _characterRepository;

        public Account LoggedInAccount { get; set; }

        public AccountPage(Account loggedInAccount)
        {
            InitializeComponent();

            LoggedInAccount = loggedInAccount;

            _authPage = new AuthPage(loggedInAccount);
            _characterRepository = new CharacterRepository();

            var characterList = LoggedInAccount.Characters;

            listOfCharacters.ItemsSource = characterList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewCharacter(LoggedInAccount));
        }

        private void LogoClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }

        private void Enter_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedCharacters = listOfCharacters.SelectedItems;

            foreach (var selectedCharacter in selectedCharacters)
            {
                MessageBox.Show($"{selectedCharacter}");
            }
        }
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = listOfCharacters.SelectedIndex;

            _characterRepository.DeleteCharacter(selectedIndex, LoggedInAccount.Id);

            NavigationService.Navigate(new AccountPage(LoggedInAccount));
        }
    }
}
