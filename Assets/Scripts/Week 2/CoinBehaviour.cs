using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public float movementSpeed = 10f;//Controls speed of oscilating movement

    public float roatationSpeed = 50f;//Controls speed of coin rotation


    public float amplitude = 0.1f;//Controls magnitude of sine movement


    private Vector3 startPos;//Stores beginning position of coin to apply offset to

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;//Gets staring position of coin on game start

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, roatationSpeed * Time.deltaTime);//Rotates coin according to vector forward according to rotation speed and deltaTime

        float verticalMovement = Mathf.Sin(Time.time * movementSpeed) * amplitude;//Calculates sine movement using amplitude and movement speed

        Vector3 newPos = startPos + Vector3.up * verticalMovement; //Applies offset of vertical movement to objects up vector from start position
        transform.position = newPos;//Applies previous application to game objects position every frame

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))//If player is detected to collide with coin
        {
            GameManager gameManager = FindObjectOfType<GameManager>();//Creates reference to scene's game manager

            if (gameManager != null)//Checks that game manager does exist in scene to prevent errors from occuring
            {
                 gameManager.AddCollectedCoin(1);//Calls AddCollectedCoin method from game manager adding 1
            }
            Destroy(gameObject); //Coin is destroyed.
        }
    }
}
