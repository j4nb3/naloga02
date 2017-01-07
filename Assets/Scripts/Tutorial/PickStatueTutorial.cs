using UnityEngine;
using System.Collections;

public class PickStatueTutorial : MonoBehaviour {

    private bool inRange = false;

    void Update(){
        if (Input.GetKeyDown(KeyCode.F) && inRange == true)
        {
            Destroy(GameObject.Find("DragonStatue"));
            Application.LoadLevel("MainScene");
        }
    }

    void OnTriggerEnter()
    {
        TutorialText.changeDisplayText("Press F to pick up", 2);
        inRange = true;
    }

}
