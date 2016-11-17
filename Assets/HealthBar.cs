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
    FirstPersonController fpc;
    float sprint, walk;
    bool regenST = true;
    // Use this for initialization
    void Start () {
        Health.value = max_HP;
        Stamina.value = max_ST;
        InvokeRepeating("Heal", 5, 5); //poveča HP vsakih 5 sekund za +2
        InvokeRepeating("Stam", 3, 3); //poveča ST vsakih 3 sekund za +5
        fpc = GameObject.FindObjectOfType<FirstPersonController>();
        walk = (float)fpc.m_WalkSpeed;
        sprint = (float)fpc.m_RunSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        HP.text = Health.value.ToString("0") + "/" + max_HP.ToString("0");
        ST.text = Stamina.value.ToString("0")+ "/" + max_ST.ToString("0");
        fpc.m_RunSpeed = sprint;
        regenST = true;
        if (Health.value <=0)
        {
            Dead();
            Application.LoadLevel(0); //naloži death sceno (ko bo) 
        }

        if (Input.GetKey("left shift"))
        {
            regenST = false;
            Stamina.value -= 1;
        }
        if(Stamina.value<=0)
        {
            fpc.m_RunSpeed = walk;
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
    void Dead()
    {
        Debug.Log("Player Died");
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            Health.value -= 1;
        }
    }

}
