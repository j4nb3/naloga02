using UnityEngine;
using System.Collections;

public class Tutorial5 : MonoBehaviour {

    public static string text = "You can defend yourself against monsters using weapons";
    public static string text2 = "Weapons can be found all over maze in chests";

    void OnTriggerEnter()
    {
        //UIscript.GetComponent<UnityEngine.UI.Text>().text = text;
        //wait 3s
        //UIscript.GetComponent<UnityEngine.UI.Text>().text = text2;
    }
}
