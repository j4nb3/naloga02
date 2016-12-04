using UnityEngine;
using System.Collections;

public class Tutorial4 : MonoBehaviour {

    public static string text1 = "Fire and monsters damages your health \n if it reaches 0 you die";
    public static string text2 = "Just like stamina it regenerates over time \n but at a slower rate";

    void OnTriggerEnter()
    {
        TutorialText.changeDisplayText(text1, 2);
        TutorialText.changeDisplayText(text2, 2);
    }
}
