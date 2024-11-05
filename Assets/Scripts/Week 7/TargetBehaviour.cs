using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    private GameObject player;

    public float movementSpeed;

    private int healthPoints;

    void Start()
    {
        healthPoints = Random.Range(1, 4);

        movementSpeed = Random.Range(5, 10);

         
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       //LookAtPlayer();

       //MoveTowardsPlayer();
    }

    void LookAtPlayer()
    {
        transform.LookAt(player.transform);
    }

    void MoveTowardsPlayer()
    {
        transform.position += transform.forward * (movementSpeed * Time.deltaTime);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           SpawnTarget spawner = FindObjectOfType<SpawnTarget>();

           if(spawner != null)
           {
               spawner.CreateNewTarget();
           }
           Destroy(gameObject);

        }
    }

    public int GetHealthPoints()
    {
        return healthPoints;
    }



}