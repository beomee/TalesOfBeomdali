using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform enemyTransform;
    private Transform playerTransform;
    private NavMeshAgent navMesh;

    protected int enemyHp;
    protected int enemyStr;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyTransform = gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        navMesh.destination = playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
