using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class helper : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int y = SceneManager.GetActiveScene().buildIndex;
        print(y);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
        