using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandom : MonoBehaviour {

    NavMeshAgent agent;
    NavMeshPath path;
    Animator animator;
    public GameObject gb;
    bool inNavigation;
    public int waitTime;
    public int walkTime;
    bool startNaveEnd = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        animator = gb.GetComponent<Animator>();
    }

    void Update()
    {
        if (!inNavigation)
        {
            StartCoroutine(startNavigation());
        }
        else {
            if (Vector3.Distance(transform.position, agent.destination) <= 3f || startNaveEnd)
            {
                StartCoroutine(finishNavigation());
            }
        }
    }

    IEnumerator startNavigation()
    {
        inNavigation = true;
        animator.SetBool("isWalking", true);
        Vector3 randomDirection = Random.insideUnitSphere * 25;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 25, 1);
        Vector3 finalPosition = hit.position;
        agent.SetDestination(finalPosition);
        gb.GetComponent<NavMeshAgent>().isStopped = false;
        yield return new WaitForSeconds(walkTime);
        startNaveEnd = true;
    }

    IEnumerator finishNavigation()
    {
        animator.SetBool("isWalking", false);
        gb.GetComponent<NavMeshAgent>().isStopped = true;
        yield return new WaitForSeconds(waitTime);
        startNaveEnd = false;
        inNavigation = false;
    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }
}
