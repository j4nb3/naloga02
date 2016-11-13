using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

    bool isInRange;
    bool itemExists = true;
    public AudioClip sound;

	void Start () {
	    
	}

    void onTriggerEnter()
    {
        isInRange = true;
    }

    void onTriggerExit()
    {
        isInRange = false;
    }

    void OnGUI()
    {
        if(isInRange == true)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.width / 2, 100, 100), "Press [f] to search chest");
        }
    }

    void Update()
    {
        if (isInRange == true)
        {
            if (Input.GetKeyDown("f"))
            {
                AudioSource.PlayClipAtPoint(sound, transform.position);
                if(itemExists == true)
                {
                    GUI.Label(new Rect(Screen.width / 2, Screen.width / 2, 100, 100), "You found an item!");
                    itemExists = false;
                }
                if(itemExists == false)
                {
                    GUI.Label(new Rect(Screen.width / 2, Screen.width / 2, 100, 100), "You already looted this chest.");
                }
                
            }
        }
    }
}
