using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour {
    public HealthBar health;
    public CrossScript ammo;
    public float PositionX, PositionY, PositionZ;
    public float hp,st;
    int noter,reload;
	// Use this for initialization
	void Start () {
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
        }

        if (Input.GetKey(KeyCode.F9))
        {
            health.Health.value=PlayerPrefs.GetFloat("HP");
            health.Stamina.value = PlayerPrefs.GetFloat("ST");
            ammo.trenutno_noter = PlayerPrefs.GetInt("Noter");
            ammo.trenutno_reload = PlayerPrefs.GetInt("Reload");

            gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));
        }
	
	}
}
