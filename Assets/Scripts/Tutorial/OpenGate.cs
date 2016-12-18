using UnityEngine;
using System.Collections;

public class OpenGate : MonoBehaviour {

    private bool odpri = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (odpri)
        {
            GameObject vrata;
            vrata = GameObject.Find("Gate");
            if(vrata.transform.position.y <= 8)
            {
                vrata.transform.Translate(0, Time.deltaTime, 0);
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        odpri = true;
    }
}