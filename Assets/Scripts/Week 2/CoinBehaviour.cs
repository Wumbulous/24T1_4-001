using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public float movementSpeed = 10f;

    public float roatationSpeed = 50f;

    public float amplitude = 0.1f;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, roatationSpeed * Time.deltaTime);

        float verticalMovement = Mathf.Sin(Time.time * movementSpeed) * amplitude;

        Vector3 newPos = startPos + Vector3.up * verticalMovement;
        transform.position = newPos;
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();

            if(gameManager != null)
            {
                 gameManager.AddCollectedCoin(1);
            }
            Destroy(gameObject);
        }
    }
}
