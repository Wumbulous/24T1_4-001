using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{

    /// <summary>
    /// OLD AND UNUSED ATTEMPT IGNORE
    /// </summary>
    private GameObject player;

    public float movementSpeed;

    public int healthPoints;

    void Start()
    {
        healthPoints = Random.Range(1, 4);

        movementSpeed = Random.Range(5, 10);

         
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       LookAtPlayer();

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
           
           Destroy(gameObject);

           OnDestroy();

        }
       
        if(collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }

    public int GetHealthPoints()
    {
        return healthPoints;
    }

    public void TakeDamage()
    {
        healthPoints = healthPoints - 1;

        if(healthPoints <= 0)
        {
            Destroy(gameObject);

            OnDestroy();
        }
    }

    void OnDestroy()
    {
      DataCharacter player = FindObjectOfType<DataCharacter>();

      if(player != null)
      {
          player.FaceNextTarget();
      }
      
      SpawnTarget spawner = FindObjectOfType<SpawnTarget>();

      if(spawner != null)
      {
        spawner.CreateNewTarget();
      }
    }
}
