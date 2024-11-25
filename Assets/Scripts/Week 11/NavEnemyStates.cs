using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Imports Ai functionality, used for pathfinding.
using UnityEngine.SceneManagement; //Imports scene management functionality, allowing the enemy to send the player to the game over screen.

public class NavEnemyStates : MonoBehaviour
{
    public Transform[] targets; //Array of points the enemy is to move between when patrolling.

    private int currentIndex = 0; //Stores current index telling which target to set destination to.

    private enum navEnemyState //Stores states enemy can be in, patrolling for going between set points, chasing for persuing the player.
    {
        Patrolling,
        Chasing
    }

    private navEnemyState currentState; //Stores current state the enemy is in.

    public Transform player; //Reference to transform of player, use position to head towards them.

    public float playerDetectionRadius = 5.0f; //Range player has to be within to have enemy start chasing them.

    private float distanceToPlayer; //Used to calculate the distancve between the player and enemy.

    private NavMeshAgent agent; //Reference to NavMeshAgent component which handles enemy navigation.

    void Start()
    {
        currentState = navEnemyState.Patrolling; //Sets enemy to be patrolling on the game starting.

        agent = GetComponent<NavMeshAgent>(); //Gets refence to NavMeshAgent component.
    }

    void Update ()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position); //Every frame calculates the distance between the enemy and the player.

        HandleState(); //Calls the HandleState method, handaling the actions of each state and switching between them.

        if (distanceToPlayer <= playerDetectionRadius) //If player enters the detection radius, if they are switch to chasing state.
        {
            ChangeState(navEnemyState.Chasing);

        }
        else if(distanceToPlayer >= playerDetectionRadius) //If player is outside the detection radius set the enemy state to patrolling.
        {
            ChangeState(navEnemyState.Patrolling);
        }
    }

    private void HandleState()
    {

        switch (currentState) //Switch used case based on the currentState variable.
        {
            case navEnemyState.Patrolling: //If enemy is set to be patrolling go between targets set in array.

                int targetsAmount = targets.Length; //Stores length of target array to make sure the enemy doesn't try to access index outside of bounds.

                agent.SetDestination(targets[currentIndex].position); //NavMeshAgent moves towards the taget at the currentIndex index.
                    
                if(agent.remainingDistance == 0f) //Checks if NavMeshAgent has reached its destination.
                {
                    currentIndex = (currentIndex + 1) % targetsAmount; //Sets the destination to the next target in the array, while keeping it in bounds preventing error.
                }
                break;

            case navEnemyState.Chasing: //If enemy is in chasing state start persuing the player.

                agent.SetDestination(player.position); //Set NavMeshAgent's destination to player's current position, either they will collide resulting in a game over or the player will outrun, putting the enemy in the patrolling state.

                break;
        }
    }

    private void ChangeState(navEnemyState newState) //Recieves desired state from update method.
    {
        currentState = newState; //Sets the current state to the new state.
    }

    void OnCollisionEnter(Collision collision) //If enemy collides with the player load the Game Over scene.
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
