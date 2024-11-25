using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Imports Ai functionality, used for pathfinding and navigation

public class AgentMover : MonoBehaviour
{
    public Transform target; //Stores transform of target the agent is to move towards

    private NavMeshAgent agent; //Reference NavMeshAgent component to handle movement

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //References and stores NavMeshAgent component, handaling navigation for GameObject

    }

    // Update is called once per frame
    void Update()
    {
        
        if(target != null) //Checks if target exists in scene, avoids errors from occuring
        {
            agent.SetDestination(target.position); //Sets agent's destination to target transform, NavMeshAgent calculates most optimal path.
        }
    }
}
