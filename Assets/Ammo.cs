using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ammo : MonoBehaviour {

    public AudioSource source;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        source.Play();   
        this.gameObject.SetActive(false);
    }
}
