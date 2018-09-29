using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandom : MonoBehaviour {

    public NavMeshAgent agent;
    NavMeshAgent navMeshAgent;
    NavMeshPath path;
    public float idleTime;
    bool inCoRoutine;
    Vector3 target;
    bool validPath;
    public GameObject gb;
    Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        animator = gb.GetComponent<Animator>();
    }

    void Update()
    {
        if (!inCoRoutine)
        {
            inCoRoutine = true;
            animator.SetBool("isWalking", true);
            Vector3 randomDirection = Random.insideUnitSphere * 100;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 100, 1);
            Vector3 finalPosition = hit.position;
            agent.SetDestination(finalPosition);
        }
        else {
            Debug.Log(Vector3.Distance(transform.position, agent.destination));
            if (Vector3.Distance(transform.position, agent.destination) <= 0.5f)
            {
                animator.SetBool("isWalking", false);
                inCoRoutine = false;
            }
        }
    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }

    void getNewPath()
    {
        target = getNewRandomPosition();
    }

}
