using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnCollisionStay(Collision collisiondetec)
    {
        //Check collision with player
        if (collisiondetec.gameObject.CompareTag("Player"))
        {
            //Destroy the object
            Destroy(gameObject); 
        }
        
    }
}
