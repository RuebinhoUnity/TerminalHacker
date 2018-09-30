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

    const string greeting = "Hello Hackerman!";
    const string menuHint = "Return to the menu with 'menu'";

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
        Terminal.WriteLine("Input the password, ");
        Terminal.WriteLine("hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void WinGame()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (levelNumber)
        {
            case 1:
                Terminal.WriteLine("Have a drink at the hotel lobby!");
                Terminal.WriteLine(@"
   ______//
   \    ///     Hotel
    \  ///
     \///       Concorde
      vv
    __||__
");
                break;
            case 2:
                Terminal.WriteLine(@"
                 _____
              .-'     `-. 
            .'  .- -.- '
           /  .'                 
      .-- - ' '--------.      Finanz
       '':  :'''''''''''
    .---- - '  '---- -.     verwaltung
     '''''\  \'''''''''
           \  `.                NRW
            '.  `-----.
              '-.____.'");
                break;
            case 3:
                Terminal.WriteLine(@"
       *  *  *  *    * * *
       *        *  *        *
       ****     **** *    *
       ****     **** *    *
       *        *  *        *
       *  *  *  *    * * *  
   Willkommen bei der AOK Systems!
");
                break;
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber)
        {
            levelNumber = int.Parse(input);
            AskForPassword();
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
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        
        password = GetRandomPasswordFromArray(levelNumber);
     
        Terminal.WriteLine("You chose lvl " + levelNumber + ": " + ReturnLevelnameByNumber(levelNumber));
        Terminal.WriteLine("Input the password, ");
        Terminal.WriteLine("hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
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
        else if (levelNumber == 3)
        {
            return lvl3name;
        }
        else
        {
            return "";
        }
    }
}
