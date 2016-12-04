using UnityEngine;
using System.Collections;

public class Tutorial5 : MonoBehaviour {

    public static string text = "You can defend yourself against monsters using weapons\nWeapons can be found all over maze in chests";
    public static string text2 = "You can also pick up health and stamina orbs \n which will regenerate health and stamina";

    void OnTriggerEnter()
    {
        TutorialText.changeDisplayText(text, 2);
        TutorialText.changeDisplayText(text2, 2);
    }
}
