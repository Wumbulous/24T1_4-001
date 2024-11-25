using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStates : MonoBehaviour
{
    public Transform[] patPoints; //Store transform off all points in scene enemy is to move towards

    private int currentIndex = 0; //Store point enemy is currently moving to within array

    private enum enemyState  //Store states enemy can be in, patrolling for moving between points, chasing for moving towards player
    {
        Patrolling,
        Chasing

    }

    private enemyState currentState; //Store enemy's current state

    public Transform player; //Reference to players location in game world.

    public float playerDetectionRadius = 5.0f; //Area player has to get within to be chased

    private float distanceToPlayer; //Distance between enemy and player

    public float movementSpeed; //Speed enemy moves at

    void Start()
    {
        currentState = enemyState.Patrolling; //At start of play have enemy already patrolling
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position); //Calculate distance between enemy and player every frame

        HandleState(); //Methos to handle state function

        //if (distanceToPlayer <=  playerDetectionRadius) //If player is close enough to enemy start chasing
        {
            //ChangeState(enemyState.Chasing);
        }

        //else if (distanceToPlayer >= playerDetectionRadius) //if player is far away from enemy patroll between points
        {
            //ChangeState(enemyState.Patrolling);
        }
    }

    private void HandleState()
    {
        switch(currentState) //Switch action depending on current enemy state
        {
           case enemyState.Patrolling: //If enemy is set to patroll move towards current patroll point in array at given speed

                int patAmount = patPoints.Length; //Store length of array to keep current index within bounds 

                transform.position = Vector3.MoveTowards(transform.position, patPoints[currentIndex].position, movementSpeed * Time.deltaTime);

                if (transform.position == patPoints[currentIndex].position) //When enemy reaches current patroll point, start moving towards next in array by 1, kept within bounds of array length
                {
                    currentIndex = (currentIndex + 1) % patAmount;
                }

                if(distanceToPlayer >= playerDetectionRadius)
                {
                    ChangeState(enemyState.Patrolling);
                }
                break;

            case enemyState.Chasing: //If enemy is set to chase, move towards player position at given speed.

                transform.position = Vector3.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);

                if(distanceToPlayer <= playerDetectionRadius) //If player is close enough to enemy start chasing
                {
                    ChangeState(enemyState.Patrolling);
                }

                break;

            
        }
    }
    private void ChangeState(enemyState newState) //Change current state to new state
    {
        currentState = newState;

    }

    void OnCollisionEnter(Collision collision) //When collide with player load game over scene.
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
