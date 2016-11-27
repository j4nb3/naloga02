using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tooltip : MonoBehaviour {

    private Text[] textFields;

    // Use this for initialization
    void Awake () {
        textFields = GetComponentsInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setText(string name, string description) {
        textFields[0].text = name;
        textFields[1].text = description;
    }
}
