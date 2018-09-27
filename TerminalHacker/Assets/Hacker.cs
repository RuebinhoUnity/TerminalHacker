using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    private string greeting = "Hello Hackerman!";
    //Game state
    int levelNumber;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    //level1 passwords
    string lvl1password = "Hotel";

    //level2 passwords
    string lvl2password = "Steuererklärung";

    // Use this for initialization
    void Start ()
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
        if (levelNumber == 1)
        {
            if (input == lvl1password)
            {
                WinGame();
            }
            else
            {
                TryAgain();
            }
        }
        
        if (levelNumber == 2)
        {
            if (input == lvl2password)
            {
                WinGame();
            }
            else
            {
                TryAgain();
            }
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
        if (input == "1")
        {
            levelNumber = 1;
            StartGame();
        }
        else if (input == "2")
        {
            levelNumber = 2;
            StartGame();
        }
        else if (input == "3")
        {
            Terminal.WriteLine("You chose lvl 3");
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
        Terminal.WriteLine(" ");
        Terminal.WriteLine("You chose lvl " + levelNumber);
        Terminal.WriteLine("Please input the correct password:");
    }
}
