using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour {
    public Text shranjeno;
    public HealthBar health;
    public CrossScript ammo;
    private float PositionX, PositionY, PositionZ;
    private float hp,st;
    int noter,reload;
	// Use this for initialization
    IEnumerator Cakaj(int x)
    {
        shranjeno.text = "";
        if (x == 1)
        {
            shranjeno.text = "Game Saved!";
        }
        else if (x == 2)
        {
            shranjeno.text = "Loaded";
        }
        yield return new WaitForSeconds(2.0f);
        shranjeno.text = "";
    }
	void Start () {
        shranjeno.text = "";

    }
	
	// Update is called once per frame
	void Update ()
    {
        hp = health.Health.value;
        st = health.Stamina.value;
        noter = ammo.trenutno_noter;
        reload = ammo.trenutno_reload;
        PositionX = gameObject.transform.position.x;
        PositionY = gameObject.transform.position.y;
        PositionZ = gameObject.transform.position.z;

        if (Input.GetKey(KeyCode.F5))
        {
            PlayerPrefs.SetFloat("HP", hp);
            PlayerPrefs.SetFloat("ST", st);
            PlayerPrefs.SetInt("Noter", noter);
            PlayerPrefs.SetInt("Reload", reload);

            PlayerPrefs.SetFloat("X", PositionX);
            PlayerPrefs.SetFloat("Y", PositionY);
            PlayerPrefs.SetFloat("Z", PositionZ);
            StartCoroutine(Cakaj(1));
        }

        if (Input.GetKey(KeyCode.F9))
        {
            health.Health.value=PlayerPrefs.GetFloat("HP");
            health.Stamina.value = PlayerPrefs.GetFloat("ST");
            ammo.trenutno_noter = PlayerPrefs.GetInt("Noter");
            ammo.trenutno_reload = PlayerPrefs.GetInt("Reload");

            gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));
            StartCoroutine(Cakaj(2));
        }
	
	}
}
