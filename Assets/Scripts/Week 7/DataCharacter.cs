using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCharacter : MonoBehaviour
{
    public GameObject bullet;

    void Update()
    {
        ShootProjectile();
    }

    void ShootProjectile()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            Instantiate(bullet, transform.position, transform.rotation );

            
        }
    }
}
