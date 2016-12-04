using UnityEngine;
using System.Collections;

public class Tutorial6 : MonoBehaviour {

    private string text = "Kill the monster in next room";

    void OnTriggerEnter()
    {
        TutorialText.changeDisplayText(text, 2);
    }
}
