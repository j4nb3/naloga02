using UnityEngine;
using System.Collections;

public class Tutorial1 : MonoBehaviour {

    private string text = "Run to the end of the hallway";

    void OnTriggerEnter()
    {
        TutorialText.changeDisplayText(text, 1);
    }
}
