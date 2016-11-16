using UnityEngine;
using System.Collections;

public class XD : MonoBehaviour {
    public float duration = 0.5F;
    public Color color0 = Color.red;
    public Color color1 = Color.blue;
    public Light lt;
    // Use this for initialization
    void Start () {
        lt = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color0, color1, t);
    }
}
