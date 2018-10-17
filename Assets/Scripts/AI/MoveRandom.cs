using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/**
 * A class to control the AI movement so that the AI can move randomly in the scene.
 */
public class MoveRandom : MonoBehaviour {

    NavMeshAgent agent;
    Animator animator;
    public GameObject npc;
    public int walkTime;
    public GameObject player;
    bool inCoroutine;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = npc.GetComponent<Animator>();
    }

    void Update()
    {
        //Stop walking when the AI is too closed to the player.
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

    //Started navigating to the destiney
    private IEnumerator StartNavigation()
    {
        animator.SetBool("isWalking", true);
        Vector3 randomDirection = Random.insideUnitSphere * 25;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 25, 1);
        Vector3 finalPosition = hit.position;
        agent.SetDestination(finalPosition);
        npc.GetComponent<NavMeshAgent>().isStopped = false;
        yield return new WaitForSeconds(walkTime);
        animator.SetBool("isWalking", false);
        npc.GetComponent<NavMeshAgent>().isStopped = true;
        inCoroutine = false;
    }

    //Stop Navigating to the destiney
    private void StopNavigation()
    {
        animator.SetBool("isWalking", false);
        npc.GetComponent<NavMeshAgent>().isStopped = true;
    }

    //Get a random position
    private Vector3 GetNewRandomPosition()
    {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }
}
