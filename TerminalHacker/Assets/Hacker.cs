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
        Terminal.WriteLine("You chose lvl " + levelNumber);
    }
}
