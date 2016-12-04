using UnityEngine;
using System.Collections;

public class Tutorial5 : MonoBehaviour {

    public static string text = "You can defend yourself against monsters using weapons\nWeapons can be found all over maze in chests";

    void OnTriggerEnter()
    {
        TutorialText.changeDisplayText(text, 2);
    }
}
