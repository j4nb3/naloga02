using UnityEngine;
using System.Collections;

public class Tutorial3 : MonoBehaviour {

    private string text = "It replenishes over time";

    void OnTriggerEnter()
    {
        TutorialText.changeDisplayText(text, 2);
    }
}
