using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnough : MonoBehaviour
{
    public Transform player; //Reference to player transform

    public float detectionDistance = 5.0f; //Area around object used to detect if the player is close

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position); //Calculates distance between object and player positions
        if (distanceToPlayer <= detectionDistance) //If distance between is less than detection radius print "player is near"
        {
            print("Player is near");
        }

        else //If player is outside of detection radius print "player is farr"
        {
            print("Player is far");
        }
    }
}
