using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coin;               //object to spawn
    public int numberToSpawn = 10;       // number of objects want to spawn
    public float distanceCoin = 2.0f;    //distance between coin placement 

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            Instantiate(coin, new Vector3(i * distanceCoin, 0, 0), Quaternion.Euler(-90, 0, 0));//Creates new coin at a distance of the given distanceCoin variable from the last
        }
        
    }

}
