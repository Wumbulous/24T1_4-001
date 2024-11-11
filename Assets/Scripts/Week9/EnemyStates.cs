using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    public Transform[] patTargets;

    private enum enemyState
    {
        Patrolling,
        Chasing

    }

    private enemyState currentState;

    public Transform player;

    public float playerDetectionRadius = 5.0f;

    private float distanceToPlayer;

    public float movementSpeed;

    private int currentIndexNum;
    // Start is called before the first frame update
    void Start()
    {
        currentState = enemyState.Patrolling;

        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        HandleState();

        if (distanceToPlayer <=  playerDetectionRadius)
        {
            ChangeState(enemyState.Chasing);
        }

        else if (distanceToPlayer >= playerDetectionRadius)
        {
            ChangeState(enemyState.Patrolling);
        }
    }

    private void HandleState()
    {
        switch(currentState)
        {
            case enemyState.Chasing:

                ChasePlayer();
                    break;

            case enemyState.Patrolling:
                PatrolPoints();
                    break;
        }
    }
    private void ChangeState(enemyState newState)
    {
        currentState = newState;

        Debug.Log("Enemy is: " + currentState);
    }

    void ChasePlayer()
    {
        transform.LookAt(player.transform);

        transform.position += transform.forward * (movementSpeed * Time.deltaTime);
    }

    void PatrolPoints()
    {
        int targetCount = patTargets.Length; 

       

       Transform nextPoint = patTargets[currentIndexNum];

       transform.LookAt(nextPoint.transform);

       transform.position += transform.forward * (movementSpeed * Time.deltaTime);
      
    
    }
}
