using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    public GameObject enemy;

    

    private Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
         CreateNewTarget();
         CreateNewTarget();
         CreateNewTarget();
    }

    public void CreateNewTarget()
    {
        Instantiate(enemy, transform.position + new Vector3(0, 0, Random.Range(-20, 20)), Quaternion.identity);
    }
    
}
