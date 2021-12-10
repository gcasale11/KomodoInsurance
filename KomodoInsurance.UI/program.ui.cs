using DeveloperRepo;
using DevTeamRepo;
using Developer.POCO;
using DevTeam.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance.UI
{
    class ProgramUI
    {
        private readonly DevRepo _devrepo = new DevRepo();
        private readonly DeveloperTeamRepo _devteamrepo = new DeveloperTeamRepo();


        public void RUN()
        {
            Seed();
            RunApplication();
        }

        public void Menu()
        {
            //create team, add developers

            Console.WriteLine("Welcome to Komodo Insurance. Feel free to manage your teams and developers\n" +
                "1. Create Developer\n" +
                "2. View All Developer\n" +
                "3. Create a Team\n" +
                "4. Add Developer to Your Team\n" +
                "5. Remove Developer from Team\n" +
                "6. View All Team\n" +
                "7. Remove Developer from Database\n" +
                "8. Exit");

        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Menu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateDeveloper();
                        break;
                    case "2":
                        ViewAllDeveloper();
                        break;
                    case "3":
                        CreateATeam();
                        break;
                    case "4":
                        AddDeveloperToYourTeam();
                        break;
                    case "5":
                        RemoveDevloperFromTeam();
                        break;
                    case "6":
                        ViewAllTeam();
                        break;
                    case "7":
                        RemoveDevloperFromDatabase();
                        break;
                    case "8":
                        GetTeamById();
                        break;
                    case "9":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }


        //Developer Crud


        //This is CreateDev from Menu
        private void CreateDeveloper() //Fin
        {
            Console.Clear();
            //get first name, last name, yes or no plural
            Console.WriteLine("Please input the developer's first name:");
            string userInputFirstName = Console.ReadLine();

            Console.WriteLine("Please input the developer's last name:");
            string userInputLastName = Console.ReadLine();

            Dev devnew = new Dev(userInputFirstName, userInputLastName);

            Console.WriteLine("Do they have access to Pluralsight\n" +
                "1. Yes\n" +
                "2. No");
            string userInputAcessToPluralsight = Console.ReadLine();


            if (userInputAcessToPluralsight == "1")
            {
                devnew.isAccessingPluralsight = true;
                Console.WriteLine($"{userInputFirstName} {userInputLastName} does have access to Pluralsight.");
            }
            else

            {
                devnew.isAccessingPluralsight = false;
                Console.WriteLine($"{userInputFirstName} {userInputLastName} does NOT have access to Plurasight. Hit any key to continue");
                Console.ReadKey();
            }

            bool isSuccessful = _devrepo.AddDeveloperToList(devnew);
            if (isSuccessful) //true
            {
                Console.WriteLine($"{userInputFirstName} {userInputLastName} was succesfully added to the database.");
            }
            else
            {
                Console.WriteLine($"{userInputFirstName} {userInputLastName} was NOT succesfully added to the database.");
            }
            Console.WriteLine("Press enter to go back to Menu");
            Console.ReadLine();
        }


        //helper method for displaying developer
        private void DisplayDeveloperInfo(Dev developer) // fin: in order to display we need to pass in developer arguments.
        {
            Console.WriteLine($"{developer.DevID}\n" +
                $"{developer.FirstName}\n" +
                $"{developer.LastName}\n" +
                $"{developer.isAccessingPluralsight}");
            Console.WriteLine("***********************");
        }
        //This is ViewAll Dev from Menu
        private void ViewAllDeveloper() //Fin
        {
            Console.Clear();
            List<Dev> listOfAllDevelopers = _devrepo.GetDeveloperList();
            foreach (Dev developer in listOfAllDevelopers) //dev or var
            {
                DisplayDeveloperInfo(developer); //passing through developer 
            }
            Console.ReadKey(); //press anything to exit method
        }

        private void RemoveDevloperFromDatabase()//Fin
        {
            Console.Clear();
            Console.WriteLine("Which developer are you removing from your list?\n" +
                "press anykey to pull up developer list");
            Console.ReadKey();
            ViewAllDeveloper();
            Console.WriteLine("Type the ID of the developer you want to remove from your database:");
            int userInputForRemoval = Convert.ToInt32(Console.ReadLine());
            //Dev developerRemovedFromDatabase = _
            _devrepo.RemoveDeveloperFromList(userInputForRemoval);
            Console.WriteLine($"{ userInputForRemoval} has been removed from the database");
            Console.ReadLine();
        }



        //Team Crud


        private void ViewAllTeam()//Fin
        {
            Console.Clear();
            List<DeveloperTeam> listOfTeams = _devteamrepo.ViewDeveloperTeamList();
            foreach (DeveloperTeam team in listOfTeams)
            {
                DisplayTeamInfo(team);
            }
            Console.ReadLine();
        }

        private void RemoveDevloperFromTeam()
        {
            ViewAllTeam();
            Console.WriteLine("Choose which Team ID you want to remove a developer from?");
            int userTeamIdInput = Convert.ToInt32(Console.ReadLine());
            var team = _devteamrepo.GetTeamById(userTeamIdInput);
            Console.WriteLine("Now choose which developer you want to remove?");
            foreach (var member in team.GetDeveloperList)
            {
                Console.WriteLine($"{member.DevID} {member.FirstName} {member.LastName}");
            }
            int userDevInputHere = int.Parse(Console.ReadLine());

            _devteamrepo.RemoveTeamMember(userTeamIdInput, userDevInputHere);

            Console.WriteLine($"{userDevInputHere} has been removed from your team");
            Console.ReadLine();
        }

        //This is AddDeveloper to Existing Team Menu
        private void AddDeveloperToYourTeam()
        {
            //get id for developer and team
            ViewAllDeveloper();
            Console.WriteLine("Type the ID of the developer you want to add to your team?");
            int userInput = Convert.ToInt32(Console.ReadLine()); //taking user input and converting to int, and storing in userInput

            Dev developerAddedToTeam = _devrepo.GetDeveloperById(userInput);
            DisplayDeveloperInfo(developerAddedToTeam);

            Console.WriteLine($"You would like to add {developerAddedToTeam} to your team?\n" +
                $"1. Yes;" +
                $"2. No");
            string userInputAdding = Console.ReadLine();

            if (userInputAdding == "1")
            {
                //newTeam.GetDeveloperList.Add(developerAddedToTeam);
                Console.WriteLine($"Wonderful, {developerAddedToTeam} has been added to the team!");
                Console.ReadLine();
            }
        }

        private void CreateATeam() //Fin
        {
            DeveloperTeam newTeam = new DeveloperTeam();
            Console.Clear();
            Console.WriteLine("Please create a team name:");
            string userInputTeamName = Console.ReadLine();
            List<Dev> devs = new List<Dev>();


            bool isSuccessful = _devteamrepo.CreateTeam(newTeam);
            if (isSuccessful)
            {
                Console.WriteLine("What developers do you want to add to this team?");
                ViewAllDeveloper();
                Console.WriteLine("Choose which developer ID you want to add");
                int userInputAddDevToTeam = int.Parse(Console.ReadLine());
                string userInput = Console.ReadLine();

                while (userInput == "y")
                {
                    Console.WriteLine("Please add dev");
                    int id = int.Parse(Console.ReadLine());
                    var dev = _devrepo.GetDeveloperById(id);
                    devs.Add(dev);

                    Console.WriteLine("user added would you like to add another? y/n");
                    userInput = Console.ReadLine();
                }
                newTeam.GetDeveloperList = devs;

                Console.WriteLine($"{userInputAddDevToTeam} and {userInputTeamName} was successfully added to the database");

                Console.WriteLine("Let's add more press any key to go back");
                Console.ReadLine();

            }
            else
            {
                Console.Write($"{userInputTeamName} was NOT succesfully added to the database");
            }
            Console.WriteLine("Press enter to go back to Menu");
            Console.ReadLine();
        }

        private void UpdateTeam()
        {
            int id = int.Parse(Console.ReadLine());
            var team = _devteamrepo.GetTeamById(id);
            List<Dev> newList = team.GetDeveloperList;

            Console.WriteLine("Would you like to change the name?");
            team.TeamName = Console.ReadLine();


            Console.WriteLine("Add or remove dev 1 or 2");
            string userInput = Console.ReadLine();

            while (userInput == "1")
            {
                Console.WriteLine("Please add dev");
                int devid = int.Parse(Console.ReadLine());
                var dev = _devrepo.GetDeveloperById(devid);
                newList.Add(dev);

                Console.WriteLine("user added would you like to add another? 1 or 2");
                userInput = Console.ReadLine();
            }

            while (userInput == "2")
            {
                Console.WriteLine("Please remove dev");
                int devid = int.Parse(Console.ReadLine());
                var dev = _devrepo.GetDeveloperById(devid);
                newList.Remove(dev);

                Console.WriteLine("user removed would you like to remove another? y/n");
                userInput = Console.ReadLine();
            }
            team.GetDeveloperList = newList;

            _devteamrepo.UpdateTeam(id, team);
        }

        private void GetTeamById()
        {
            Console.WriteLine("Who you want");
            int id = int.Parse(Console.ReadLine());
            var team = _devteamrepo.GetTeamById(id);
            DisplayTeamInfo(team);
        }


        //helper method for displaying developer team
        private void DisplayTeamInfo(DeveloperTeam devTeam) // fin
        {
            Console.Write($"{devTeam.TeamID}\n" +
                $"{devTeam.TeamName}\n");
            foreach (Dev devs in devTeam.GetDeveloperList)
            {
                DisplayDeveloperInfo(devs);
            }
            Console.WriteLine("*********************");
            Console.ReadKey();
        }


        private void Seed()
        {
            Dev dev1 = new Dev("Grace", "Casale", 1, true);
            Dev dev2 = new Dev("Jake", "Walker", 2, true);
            Dev dev3 = new Dev("Craig", "UglyMug", 3, false);
            _devrepo.AddDeveloperToList(dev1);
            _devrepo.AddDeveloperToList(dev2);
            _devrepo.AddDeveloperToList(dev3);

            DeveloperTeam team1 = new DeveloperTeam("CoolKids", 1, new List<Dev> { dev1, dev2, dev3 });
            _devteamrepo.CreateTeam(team1);
        }
    }
}


