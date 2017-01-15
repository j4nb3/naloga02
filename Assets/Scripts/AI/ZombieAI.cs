using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]

public class ZombieAI : MonoBehaviour {

    public Pathfinding pathfinding;
    public Transform target;

    private Transform m_transform;
    private float m_rotationSpeed = 3.00f;

    void Start() {
        m_transform = GetComponent<Transform>();
    }

    void OnAnimatorMove() {
        Animator animator = GetComponent<Animator>();

        List<Node> path = pathfinding.FindPath(m_transform.position, target.position);

        if (animator && path != null && path.Count >= 2) {
            //m_transform.rotation = Quaternion.Slerp(m_transform.rotation, Quaternion.LookRotation(player.transform.position - m_transform.position - new Vector3(0,1,0)), m_rotationSpeed * Time.deltaTime);            
            m_transform.rotation = Quaternion.Slerp(m_transform.rotation, Quaternion.LookRotation(path[1].worldPosition - m_transform.position), m_rotationSpeed * Time.deltaTime);
            Vector3 newPosition = m_transform.position + m_transform.forward * animator.GetFloat("Walkspeed") * Time.deltaTime;
            newPosition.y = 0;
            m_transform.position = newPosition;
            animator.SetFloat("DistanceToPlayer", Vector3.Distance(m_transform.position, target.position));
        }
    }
}