using UnityEngine;
using System.Collections;

public class Dummy : MonoBehaviour {

    public int life = 300;

    void ApplyDamage(int damage)
    {
        life -= damage;
        if(life == 0)
        {
            Destroy(gameObject);
        }
    }
}
