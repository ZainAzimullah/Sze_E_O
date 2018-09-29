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
    public int waitTimeBeforeNextDest;

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
            inNavigation = true;
            animator.SetBool("isWalking", true);
            Vector3 randomDirection = Random.insideUnitSphere * 25;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 25, 1);
            Vector3 finalPosition = hit.position;
            agent.SetDestination(finalPosition);
        }
        else {
            if (Vector3.Distance(transform.position, agent.destination) <= 1f)
            {
                StartCoroutine(finishNavigation());
            }
        }
    }

    IEnumerator finishNavigation()
    {
        animator.SetBool("isWalking", false);
        yield return new WaitForSeconds(waitTimeBeforeNextDest);
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
