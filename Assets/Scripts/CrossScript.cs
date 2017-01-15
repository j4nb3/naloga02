using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrossScript : MonoBehaviour
{
    public RawImage gor;
    public RawImage dol;
    public RawImage levo;
    public RawImage desno;

    public int trenutno_noter;
    public int trenutno_reload;
    public Text noter;
    public Text reload;

    public AudioSource strel;
    public AudioSource rel;
    public AudioSource metek;

    public GameObject prefab;
    public WeaponSystem weapon;
    public GameObject ammobar;

    // Use this for initialization
    void Start()
    {
        trenutno_noter = 0;
        trenutno_reload = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if(weapon.currentWeapon!=0)
        {
            ammobar.SetActive(false);
            return;
        }
        ammobar.SetActive(true);
        noter.text = "" + trenutno_noter;
        reload.text = "" + trenutno_reload;
        if (Input.GetMouseButtonDown(0))
        {
            if (trenutno_noter > 0)
            {
                strel.Play();
                trenutno_noter--;
                gor.GetComponent<Animator>().enabled = true;
                dol.GetComponent<Animator>().enabled = true;
                levo.GetComponent<Animator>().enabled = true;
                desno.GetComponent<Animator>().enabled = true;

                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10000f, ~LayerMask.GetMask("Zombie"))) {
                        Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
                }

                Invoke("CakajAnim", 0.08f);
                StartCoroutine(Drop());

            }
            else
            {
                if (trenutno_reload > 0)
                {
                    if (trenutno_reload > 24)
                    {
                        if (trenutno_noter == 0)
                        {
                            trenutno_noter += 24;
                            trenutno_reload -= 24;
                            rel.Play();
                        }
                        else
                        {
                            trenutno_reload = trenutno_reload - (24 - trenutno_noter);
                            trenutno_noter = trenutno_noter + (24 - trenutno_noter);
                            rel.Play();
                        }
                    }
                    else if (trenutno_reload < 24 && trenutno_reload > 0)
                    {
                        if (trenutno_noter == 0)
                        {
                            trenutno_noter = trenutno_reload;
                            trenutno_reload = 0;
                            rel.Play();
                        }
                        else if (trenutno_noter < 24)
                        {
                            trenutno_reload = trenutno_reload - (24 - trenutno_noter);
                            trenutno_noter = trenutno_noter + (24 - trenutno_noter);
                            rel.Play();
                        }
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //13 na 10
            if (trenutno_reload > 24)
            {
                if (trenutno_noter == 0)
                {
                    trenutno_noter += 24;
                    trenutno_reload -= 24;
                    rel.Play();
                }
                else
                {
                    trenutno_reload = trenutno_reload - (24 - trenutno_noter);
                    trenutno_noter = trenutno_noter + (24 - trenutno_noter);
                    rel.Play();
                }
            }
            else if (trenutno_reload < 24 && trenutno_reload > 0)
            {
                if (trenutno_noter == 0)
                {
                    trenutno_noter = trenutno_reload;
                    trenutno_reload = 0;
                    rel.Play();
                }
                else if (trenutno_noter < 24)
                {
                    trenutno_reload = trenutno_reload - (24 - trenutno_noter);
                    trenutno_noter = trenutno_noter + (24 - trenutno_noter);
                    rel.Play();
                }
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
    IEnumerator Drop()
    {
        yield return new WaitForSeconds(strel.clip.length);
        metek.Play();
    }
}
