using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MoveToTarget : MonoBehaviour {

    NavMeshAgent agent;
    Animator animator;
    public GameObject gb;
    public GameObject target;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = gb.GetComponent<Animator>();
    }

    void Update() {
        if (Vector3.Distance(agent.transform.position, target.transform.position) < 25f)
        {
            animator.SetBool("isWalking", false);
            gb.GetComponent<NavMeshAgent>().isStopped = true;
        }
        else {
            animator.SetBool("isWalking", true);
            agent.SetDestination(target.transform.position);
        }
    }
}
