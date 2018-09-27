﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandom : MonoBehaviour {

    NavMeshAgent navMeshAgent;
    NavMeshPath path;
    public float timeForNewPath;
    bool inCoRoutine;
    Vector3 target;
    bool validPath;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
    }

    void Update()
    {
        if (!inCoRoutine) {
            StartCoroutine(doSomething());
        }
    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }

    IEnumerator doSomething()
    {
        inCoRoutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        getNewPath();
        validPath = navMeshAgent.CalculatePath(target, path);
        if (!validPath) {
            Debug.Log("found an invalid path");
        }

        while (!validPath)
        {
            yield return new WaitForSeconds(0.01f);
            getNewPath();
            validPath = navMeshAgent.CalculatePath(target, path);
        }
        inCoRoutine = false;
    }

    void getNewPath()
    {
        target = getNewRandomPosition();
        navMeshAgent.SetDestination(getNewRandomPosition());
    }

}
