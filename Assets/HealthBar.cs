using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class HealthBar : MonoBehaviour {
    public int max_HP = 500;
    public int max_ST = 300;
    public Slider Health;
    public Slider Stamina;
    public Text HP;
    public Text ST;
    public Text time;
    public Text ura;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;
    public GameObject deathScreen;

    public AudioSource source;
    public AudioSource regen;

    float baseFOV;

    FirstPersonController fpc;
    float sprint, walk;
    bool regenST = true;
    float skok;
    bool predvajaj=false,predvajaj1=false;
    bool zvok1=true, zvok2=true;
    // Use this for initialization
    void Start () {
        Health.value = max_HP;
        Stamina.value = max_ST;
        InvokeRepeating("Heal", 5, 5); //poveča HP vsakih 5 sekund za +2
        InvokeRepeating("Stam", 3, 3); //poveča ST vsakih 3 sekund za +5
        fpc = GameObject.FindObjectOfType<FirstPersonController>();
        walk = (float)fpc.m_WalkSpeed;
        sprint = (float)fpc.m_RunSpeed;
        skok = fpc.m_JumpSpeed;
        secondsCount = 0.0f;
        baseFOV = Camera.main.fieldOfView;
}

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(1))
        {
            Camera.main.fieldOfView = 50;
        }
        else
        {
            Camera.main.fieldOfView = baseFOV;
        }
        PosodobiUro();
        datum();
        if (fpc.m_PreviouslyGrounded && !fpc.m_CharacterController.isGrounded)
        {
            Stamina.value -= 10;
            regenST = false;
        }
        HP.text = Health.value.ToString("0") + "/" + max_HP.ToString("0");
        ST.text = Stamina.value.ToString("0")+ "/" + max_ST.ToString("0");
        fpc.m_RunSpeed = sprint;
        regenST = true;
        if (Health.value <=0)
        {
            fpc.die();
            Time.timeScale = 0.0f;
            deathScreen.SetActive(true);
            Cursor.visible = true;
        }

        if (Input.GetKey("left shift") && fpc.m_MoveDir.x!=0f)
        {
            regenST = false;
            Stamina.value -= 1;
        }
        if(Stamina.value<=0)
        {
            fpc.m_RunSpeed = walk;
            fpc.m_JumpSpeed = -1;
        }
        if (Stamina.value >= 10)
        {
            fpc.m_JumpSpeed = skok;
        }
        if(predvajaj==true)
        {
            if(Health.value!= max_HP || Stamina.value!= max_ST)
            {
                StartCoroutine(Zvok());
            }           
        }
        if (predvajaj1 == true)
        {

            StartCoroutine(Reg());
        }

    }
    void datum()
    {
        string datum = System.DateTime.Now.ToString("HH:mm:ss");
        ura.text = datum;
    }
    public void PosodobiUro()
    {
        secondsCount += Time.deltaTime;
        time.text = "ČAS IGRANJA"+"\n"+" "+hourCount + "h : " + minuteCount + "m : " + (int)secondsCount + "s";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }
    IEnumerator Zvok()
    {
        predvajaj = false;
        source.Play();
        yield return new WaitForSeconds(1.0f);
        if(zvok1==false)
        {
            predvajaj = false;
        }
        else
        {
            predvajaj = true;
        }
    }
    IEnumerator Reg()
    {
        predvajaj1 = false;
        regen.Play();
        yield return new WaitForSeconds(1.5f);
        if (zvok2 == false)
        {
            predvajaj1 = false;
        }
        else
        {
            predvajaj1 = true;
        }
    }
    void Heal()
    {
        if (Health.value != max_HP && Health.value > 0)
        {
            Health.value += 2;
        } 
    }
    void Stam()
    {
        if (Stamina.value != max_ST && regenST==true)
        {
            Stamina.value += 5;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            Health.value -= 1;
        }
        if (other.gameObject.tag == "HP1")
        {
            Health.value += 1;
        }
        if (other.gameObject.tag == "ST1")
        {
            Stamina.value += 1;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Fire")
        {
            predvajaj = false;
            zvok1 = false;
        }
        if (other.gameObject.tag == "HP1")
        {
            predvajaj1 = false;
            zvok2 = false;
        }
        if (other.gameObject.tag == "ST1")
        {
            predvajaj1 = false;
            zvok2 = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Fire")
        {
            predvajaj = true;
            zvok1 = true;
        }
        if (other.gameObject.tag == "HP1")
        {
            predvajaj1 = true;
            zvok2 = true;
        }
        if (other.gameObject.tag == "ST1")
        {
            predvajaj1 = true;
            zvok2 = true;
        }
        if (other.gameObject.tag=="HP")
        {
            if (Health.value!=max_HP)
            {
                Health.value += 100;
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == "Stam")
        {
            if (Stamina.value != max_ST)
            {
                Stamina.value += 50;
                Destroy(other.gameObject);
            }
        }
        if(other.gameObject.tag=="Posast")
        {
            Health.value -= 50;
        }
    }

}
