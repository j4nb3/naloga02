using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class ZombieAI : MonoBehaviour {

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController player;

    private Transform m_transform;
    private float m_rotationSpeed = 3.00f;

    void Start() {
        m_transform = GetComponent<Transform>();
    }

    void OnAnimatorMove() {
        Animator animator = GetComponent<Animator>();

        if (animator) {
            m_transform.rotation = Quaternion.Slerp(m_transform.rotation, Quaternion.LookRotation(player.transform.position - m_transform.position - new Vector3(0,1,0)), m_rotationSpeed * Time.deltaTime);
            m_transform.position += m_transform.forward * animator.GetFloat("Walkspeed") * Time.deltaTime;
        }
    }
}