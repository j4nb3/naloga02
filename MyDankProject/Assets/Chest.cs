using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

    bool buttonInRange;
    public AudioClip impact;

    void Start () {

    }
    
    void OnTriggerEnter()
    {
        buttonInRange = true;
    }

    void OnTriggerExit()
    {
        buttonInRange = false;
    }

    void OnGUI()
    {
        if(buttonInRange == true)
        {
            GUI.Label(new Rect(Screen.width/2, Screen.height/2, 200, 100), "Press [f] to search chest");
        }
    }

	void Update () {
        if(buttonInRange == true)
        {
            if (Input.GetKeyDown("f"))
            {
                AudioSource.PlayClipAtPoint(impact, transform.position);
                print("YOU FOUND WEAPONS TO DEFEND YERSELF AGAINST THE MONSTERS");
                Destroy(gameObject);

            }

        }
	}
}
