using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    private string greeting = "Hello Hackerman!";

	// Use this for initialization
	void Start ()
    {
        print("Hello Console!");
        ShowMainMenu(greeting);
    }

    private void ShowMainMenu(string greeting)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What do you want to hack ?");
        Terminal.WriteLine("Press <1> for Hotel Concorde");
        Terminal.WriteLine("Press <2> for Finanzamt");
        Terminal.WriteLine("Press <3> for AOK Systems");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Enter your selection:");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
