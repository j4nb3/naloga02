using UnityEngine;
using System.Collections;

public class WeaponSystem : MonoBehaviour {

    public int currentWeapon = 0;
    public int maxWeapons = 3;
    public Animator theAnimator;

    int hit01Streak = 0;
    int hit02Streak = 0;

    float damageDelay = 0.6f;

	void Awake () {
        SelectWeapon(0);
	}
	
	void Update () {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(currentWeapon + 1  <= maxWeapons)
            {
                currentWeapon++;
            }
            else
            {
                currentWeapon = 0;
            }
            SelectWeapon(currentWeapon);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(currentWeapon - 1 >= 0)
            {
                currentWeapon--;
            }
            else
            {
                currentWeapon = maxWeapons;
            }
            SelectWeapon(currentWeapon);
        }
        if(currentWeapon == maxWeapons + 1)
        {
            currentWeapon = 0;
        }
        if(currentWeapon == -1)
        {
            currentWeapon = maxWeapons;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
            SelectWeapon(currentWeapon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
            SelectWeapon(currentWeapon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
            SelectWeapon(currentWeapon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentWeapon = 3;
            SelectWeapon(currentWeapon);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(AttackDamage());
        }
    }

    void SelectWeapon(int index)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(i == index)
            {
                if(transform.GetChild(i).name == "Fists")
                {
                    theAnimator.SetBool("WeaponIsOn", false);
                }
                else
                {
                    theAnimator.SetBool("WeaponIsOn", true);
                }
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    IEnumerator AttackDamage()
    {
        if(Random.value >= 0.5 && hit01Streak <= 2)
        {
            theAnimator.SetBool("Hit01", true);
            hit01Streak += 1;
            hit02Streak = 0;
        }
        else
        {
            if(hit02Streak <= 2)
            {
                theAnimator.SetBool("Hit02", true);
                hit01Streak = 0;
                hit02Streak += 1;
            }
            else
            {
                theAnimator.SetBool("Hit01", true);
                hit01Streak += 1;
                hit02Streak = 0;
            }
        }
        
        yield return new WaitForSeconds(damageDelay);

        theAnimator.SetBool("Hit01", false);
        theAnimator.SetBool("Hit02", false);
    }
}
