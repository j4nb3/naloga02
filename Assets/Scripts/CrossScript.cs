using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrossScript : MonoBehaviour {
    public RawImage gor;
    public RawImage dol;
    public RawImage levo;
    public RawImage desno;

    private int trenutno_noter;
    private int trenutno_reload;
    public Text noter;
    public Text reload;

    // Use this for initialization
    void Start ()
    {
        trenutno_noter = 0;
        trenutno_reload = 20;
    }
	
	// Update is called once per frame
	void Update ()
    {
        noter.text = "" + trenutno_noter;
        reload.text = "" + trenutno_reload;
        if (Input.GetMouseButtonDown(0))
        {
            if(trenutno_noter > 0)
            {
                trenutno_noter--;
                gor.GetComponent<Animator>().enabled = true;
                dol.GetComponent<Animator>().enabled = true;
                levo.GetComponent<Animator>().enabled = true;
                desno.GetComponent<Animator>().enabled = true;
                Invoke("CakajAnim", 0.08f);
            }
            else
            {
                if(trenutno_reload>0)
                {
                    if(trenutno_reload>24)
                    {
                        if (trenutno_noter == 0)
                        {
                            trenutno_noter += 24;
                            trenutno_reload -= 24;
                        }
                        else
                        {
                            trenutno_reload = trenutno_reload - (24 - trenutno_noter);
                            trenutno_noter = trenutno_noter + (24 - trenutno_noter);
                        }
                    }
                    else if(trenutno_reload<24)
                    {
                        trenutno_noter += trenutno_reload;
                        trenutno_reload = 0;
                    }
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {          
            if (trenutno_reload > 24)
            {
                if(trenutno_noter==0)
                {
                    trenutno_noter += 24;
                    trenutno_reload -= 24;
                }
                else
                {
                    trenutno_reload = trenutno_reload - (24 - trenutno_noter);
                    trenutno_noter = trenutno_noter + (24 - trenutno_noter);
                }
            }
            else if (trenutno_reload < 24)
            {
                trenutno_noter += trenutno_reload;
                trenutno_reload = 0;
            }
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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ammo")
        {
            trenutno_reload += 10;
        }
    }
}
