using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using WorldofWarcraft.Managers;
using WorldofWarcraft.Models;
using WorldofWarcraft.Repositories;
using WorldofWarcraft.Repository;

namespace WorldofWarcraft
{
    public partial class NewCharacter : Page
    {
        private AccountManager _accountManager;

        private Race _race;

        private CharacterType _characterType;

        private CharacterFactory _characterFactory;

        public Account LoggedInAccount { get; set; }

        public NewCharacter(Account loggedInAccount)
        {
            InitializeComponent();

            LoggedInAccount = loggedInAccount;

            _characterFactory = new CharacterFactory();
            _accountManager = new AccountManager();
        }

        private void LogoClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AccountPage(LoggedInAccount));
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            var characterName = characterNameTextBox.Text.Trim();

            if (characterName.Length == 0)
            {
                characterNameTextBox.ToolTip = "Incorrect!";
                characterNameTextBox.Background = Brushes.Red;
            }
            else
            {
                if (Paladin.IsChecked == true && HumanPaladin.IsChecked == true)
                {
                    _characterType = CharacterType.Paladin;
                    _race = Race.Human;
                }
                if (Paladin.IsChecked == true && DwarfPaladin.IsChecked == true)
                {
                    _characterType = CharacterType.Paladin;
                    _race = Race.Dwarf;
                }
                if (Mage.IsChecked == true && HumanMage.IsChecked == true)
                {
                    _characterType = CharacterType.Mage;
                    _race = Race.Human;
                }
                if (Mage.IsChecked == true && DraeneiMage.IsChecked == true)
                {
                    _characterType = CharacterType.Mage;
                    _race = Race.Draenei;
                }
                if (Shaman.IsChecked == true && TaurenShaman.IsChecked == true)
                {
                    _characterType = CharacterType.Shaman;
                    _race = Race.Tauren;
                }
                if (Shaman.IsChecked == true && DraeneiShaman.IsChecked == true)
                {
                    _characterType = CharacterType.Shaman;
                    _race = Race.Draenei;
                }

                var character = _characterFactory.Create(characterName, _race, _characterType);

                _accountManager.AddCharacterToAccount(LoggedInAccount.Id, character);

                if (character != null)
                {
                    characterNameTextBox.Background = Brushes.Transparent;

                    MessageBox.Show($"Character {character}Is Created Successfully!");

                    NavigationService.Navigate(new AccountPage(LoggedInAccount));
                }
                else
                {
                    MessageBox.Show("Incorrect!");
                }
            }
        }
    }
}
