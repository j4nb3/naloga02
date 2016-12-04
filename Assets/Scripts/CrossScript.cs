using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrossScript : MonoBehaviour {
    public RawImage gor;
    public RawImage dol;
    public RawImage levo;
    public RawImage desno;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            gor.GetComponent<Animator>().enabled = true;
            dol.GetComponent<Animator>().enabled = true;
            levo.GetComponent<Animator>().enabled = true;
            desno.GetComponent<Animator>().enabled = true;
            Invoke("CakajAnim", 0.08f);
        }
    }
    void CakajAnim()
    {
        gor.GetComponent<Animator>().enabled = false;
        dol.GetComponent<Animator>().enabled = false;
        levo.GetComponent<Animator>().enabled = false;
        desno.GetComponent<Animator>().enabled = false;
        gor.transform.localPosition = new Vector3(0, 20, 0);
        dol.transform.localPosition = new Vector3(0, -20, 0);
        levo.transform.localPosition = new Vector3(-20, 0, 0);
        desno.transform.localPosition = new Vector3(20, 0, 0);
    }
}
