using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    //Game configuration

    //level1 data
    string lvl1name = "Hotel Concorde";
    string[] lvl1passwords = { "Hotel", "Concorde", "Mini Bar", "Wellness", "Frühstücksbuffet" };

    //level2 data
    string lvl2name = "Finanzamt";
    string[] lvl2passwords = { "Steuererklärung", "Paragraph", "Nordkirchen", "Diplomfinanzwirtin", "Verspätungszuschlag" };

    //level2 data
    string lvl3name = "AOK Systems";
    string[] lvl3passwords = { "Defragmentierungsprozess", "hochkomplex", "hochintegrativ", "Change Request", "Qualitätssicherung" };

    //Game state
    int levelNumber;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password = "";

    string greeting = "Hello Hackerman!";

    // Use this for initialization
    void Start()
    {
        print("Hello Console!");
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What do you want to hack ?");
        Terminal.WriteLine("Press <1> for Hotel Concorde");
        Terminal.WriteLine("Press <2> for Finanzamt");
        Terminal.WriteLine("Press <3> for AOK Systems");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        //TODO handle differently depending on screen
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Win)
        {

        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            WinGame();
        }
        else
        {
            TryAgain();
        }
    }

    void TryAgain()
    {
        Terminal.WriteLine("Wrong!");
        Terminal.WriteLine("Please input the correct password:");
    }

    void WinGame()
    {
        currentScreen = Screen.Win;
        Terminal.WriteLine("You're so good man! You win!");
        Terminal.WriteLine("For the menu type 'menu'");
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber)
        {
            levelNumber = int.Parse(input);
            StartGame();
        }
        else if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Welcome back Mr Bond! Choose your death");
        }
        else
        {
            Terminal.WriteLine("Please select a valid level!");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        
        password = GetRandomPasswordFromArray(levelNumber);
     
        Terminal.WriteLine("You chose lvl " + levelNumber + ": " + ReturnLevelnameByNumber(levelNumber));
        Terminal.WriteLine("Please input the correct password:");
    }

    string GetRandomPasswordFromArray(int levelNumber)
    {
        string[] pwArray = null;
        pwArray = GetPWArrayDependingOnLevelNumber(levelNumber);
        int pwArrayLength = pwArray.Length;

        int RandomIntInArray = UnityEngine.Random.Range(0, pwArrayLength);
        print(RandomIntInArray);

        return pwArray[RandomIntInArray];

    }

    string[] GetPWArrayDependingOnLevelNumber(int levelNumber)
    {
        switch(levelNumber)
        {
            case 1:
                return lvl1passwords;

            case 2:
                return lvl2passwords;

            case 3:
                return lvl3passwords;

            default:
                Debug.Log("Invalid Levelnumber");
                return null;
        }
    }

    string ReturnLevelnameByNumber(int levelNumber)
    {
        if (levelNumber == 1)
        {
            return lvl1name;
        }
        else if (levelNumber == 2)
        {
            return lvl2name;
        }
        else
        {
            return "";
        }
    }
}
