using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TutorialText : MonoBehaviour {

    Text textField;
    private static string textToDisplay;
    public static bool inProgress = false;
    private static float displayTime;

    static Queue<string> vrsta = new Queue<string>();

	void Start () {
        textField = GetComponent<Text>();
        resetText(); //Na začetku nič ne piše
        textField.color = Color.white;
    }
	
	void Update () {
        if(vrsta.Count != 0 && inProgress == false)
        {
            inProgress = true;
            textToDisplay = vrsta.Dequeue();
            displayText(displayTime);
        }
	}

    public static void changeDisplayText(string newText, float t)
    {
        vrsta.Enqueue(newText);
        displayTime = t;
    }

    /*Prikaže text na zaslonu za določeno sekund*/
    private void displayText(float t)
    {
        textField.text = textToDisplay;
        Invoke("resetText", t);
    }

    /*Izbriše text*/
    private void resetText()
    {
        textField.text = "";
        inProgress = false;
    }

}
