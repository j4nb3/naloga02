using UnityEngine;
using System.Collections;

public class EnterRoom : MonoBehaviour {

    public AudioClip impact;
    // Use this for initialization
    void Start () {
	
	}

    void onTriggerEnter()
    {
        AudioSource.PlayClipAtPoint(impact, transform.position);
    }


    // Update is called once per frame
    void Update () {

    }
}
