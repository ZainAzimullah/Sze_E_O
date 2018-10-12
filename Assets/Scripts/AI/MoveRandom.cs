using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandom : MonoBehaviour {

    NavMeshAgent agent;
    Animator animator;
    public GameObject gb;
    public int walkTime;
    public GameObject player;
    bool inCoroutine;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = gb.GetComponent<Animator>();
    }

    void Update()
    {
        if (!(Vector3.Distance(player.transform.position, agent.transform.position) < 1.4f) && !inCoroutine)
        {
            inCoroutine = true;
            StartCoroutine(StartNavigation());
        }
        else {
            if (Vector3.Distance(player.transform.position, agent.transform.position) < 1.4f || Vector3.Distance(transform.position, agent.destination) <= (double)2.0)
            {
                StopNavigation();
            }
        }
    }

    private IEnumerator StartNavigation()
    {
        animator.SetBool("isWalking", true);
        Vector3 randomDirection = Random.insideUnitSphere * 25;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 25, 1);
        Vector3 finalPosition = hit.position;
        agent.SetDestination(finalPosition);
        gb.GetComponent<NavMeshAgent>().isStopped = false;
        yield return new WaitForSeconds(walkTime);
        animator.SetBool("isWalking", false);
        gb.GetComponent<NavMeshAgent>().isStopped = true;
        inCoroutine = false;
    }

    private void StopNavigation()
    {
        animator.SetBool("isWalking", false);
        gb.GetComponent<NavMeshAgent>().isStopped = true;
    }

    private Vector3 GetNewRandomPosition()
    {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }
}
