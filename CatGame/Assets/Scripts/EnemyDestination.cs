using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDestination : MonoBehaviour
{
    public Transform goal;
    public GameObject yarn;
    
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        yarn = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (yarn.transform)
    }
}
