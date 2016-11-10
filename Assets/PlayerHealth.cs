using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public float max_Health = 100f;
    public float current_Health = 0;
    public GameObject healthBar;
	// Use this for initialization
	void Start () {
        current_Health = max_Health;
        InvokeRepeating("znizaj", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void znizaj()
    {
        current_Health -= 2f;
        float calc = current_Health / max_Health;
        SetHealthBar(calc);
    }

    public void SetHealthBar(float x)
    {
        healthBar.transform.localScale = new Vector3(x,healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

}
