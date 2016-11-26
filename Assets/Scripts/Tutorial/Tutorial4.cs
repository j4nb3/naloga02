using UnityEngine;
using System.Collections;

public class Tutorial4 : MonoBehaviour {

    public static string text1 = "Fire and monsters damages your health";
    public static string text2 = "If it reaches 0 you die";
    public static string text3 = "Just like stamina it regenerates over time";
    public static string text4 = "But at a slower rate";

    void OnTriggerEnter()
    {
        //UIscript.GetComponent<UnityEngine.UI.Text>().text = text1;
        //wait 3s
        //UIscript.GetComponent<UnityEngine.UI.Text>().text = text2;
        //wait 3s
        //UIscript.GetComponent<UnityEngine.UI.Text>().text = text3;
        //wait 3s
        //UIscript.GetComponent<UnityEngine.UI.Text>().text = text4;
    }
}
