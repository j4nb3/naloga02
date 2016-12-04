using UnityEngine;
using System.Collections;

public class Tutorial2 : MonoBehaviour {

    string text = "As you run, your stamina depletes";

    void OnTriggerEnter()
    {
        TutorialText.changeDisplayText(text, 1);
    }
}
