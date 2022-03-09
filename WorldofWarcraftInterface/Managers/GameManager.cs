using System;
using System.Collections.Generic;
using WorldofWarcraft.Models;
using WorldofWarcraft.Repositories;
using WorldofWarcraft.Repository;

namespace WorldofWarcraft.Managers
{
    public class GameManager
    {
        private List<Race> _paladinRaces = new List<Race> { Race.Human, Race.Dwarf };
        private List<Race> _mageRaces = new List<Race> { Race.Draenei, Race.Human };
        private List<Race> _shamanRaces = new List<Race> { Race.Draenei, Race.Tauren };

        private CharacterFactory _characterFactory;
        private AccountManager _accountManager;
        private Account _loggedInAccount;
        private ConsoleManager _consoleManager;

        public GameManager()
        {
            _consoleManager = new ConsoleManager();
            _characterFactory = new CharacterFactory();
            _accountManager = new AccountManager();
        }

        public void StartGame()
        {
            var selectedUserOption = _consoleManager.ShowGameMenu();
            var userName = string.Empty;
            var password = string.Empty;

            switch (selectedUserOption)
            {
                case "1":

                    _consoleManager.Clear();

                    userName = _consoleManager.GetDataFromUser("Enter your username: ", true);

                    while (true)
                    {
                        password = _consoleManager.GetDataFromUser("Enter your password: ", true);

                        var passwordToConfirm = _consoleManager.GetDataFromUser("Confirm your password: ", true);
                        var createdAccount = _accountManager.TryToCreateUserAccount(userName, password, passwordToConfirm);

                        if (createdAccount != null)
                        {
                            _loggedInAccount = createdAccount;

                            break;
                        }
                    }

                    _consoleManager.PrintMessage($"Your Account |{userName}| is created successfully!");

                    break;

                case "2":

                    _consoleManager.Clear();

                    while (true)
                    {
                        userName = _consoleManager.GetDataFromUser("Enter your username: ", true);
                        password = _consoleManager.GetDataFromUser("Enter your password: ", true);

                        _accountManager.TryToLogin(userName, password, out _loggedInAccount);

                        if(_loggedInAccount != null)
                        {
                            break;
                        }
                    }
                    
                    break;

                case "3":

                    Environment.Exit(0);

                    break;
            }

            while (true)
            {
                var selectedMenuOption = _consoleManager.ShowMenu();

                switch (selectedMenuOption)
                {
                    case "1":

                        _consoleManager.Clear();
                        _consoleManager.DisplayClasses();

                        var selectedTypeString = _consoleManager.GetDataFromUser("\nChoose your character Class: ");
                        var selectedType = (CharacterType)int.Parse(selectedTypeString);

                        List<Race> selectedTypeRaces = null;

                        switch (selectedType)
                        {
                            case CharacterType.Paladin:

                                selectedTypeRaces = _paladinRaces;

                                break;

                            case CharacterType.Mage:

                                selectedTypeRaces = _mageRaces;

                                break;

                            case CharacterType.Shaman:

                                selectedTypeRaces = _shamanRaces;

                                break;
                        }

                        _consoleManager.Clear();

                        _consoleManager.DisplayRaces(selectedTypeRaces);

                        var selectedRaceString = _consoleManager.GetDataFromUser("\nChoose your character Race: ");
                        var raceNumber = int.Parse(selectedRaceString) - 1;
                        var race = selectedTypeRaces[raceNumber];

                        _consoleManager.Clear();

                        var characterName = _consoleManager.GetDataFromUser("Enter character Name: ");
                        var character = _characterFactory.Create(characterName, race, selectedType);

                        _accountManager.AddCharacterToAccount(_loggedInAccount.Id, character);

                        _consoleManager.Clear();
                        _consoleManager.PrintMessage(character.ToString());

                        break;

                    case "2":

                        _consoleManager.Clear();

                        var characterList = _accountManager.GetCharactersList(_loggedInAccount.Id);

                        _consoleManager.DisplayCharacterList(characterList);

                        var characterIndex = int.Parse(_consoleManager.GetDataFromUser("\nEnter the character number: ")) - 1;

                        var chosenCharacter = _accountManager.GetSelectedCharacter(characterList, characterIndex);

                        _consoleManager.PrintMessage($"|CHARACTER|\n\n{chosenCharacter.ToString()}");

                        break;

                    case "3":

                        Environment.Exit(0);

                        break;

                    default:

                        _consoleManager.Clear();

                        break;
                }
            }

        }
    }

}
