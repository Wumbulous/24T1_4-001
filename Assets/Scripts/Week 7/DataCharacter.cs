using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCharacter : MonoBehaviour
{
    private DataManager dm;
    private TargetBehaviour[] targets;
    private int currentTargetIndex = 0;
    [SerializeField] private Camera playerCamera;
    public GameObject bullet;

    void Start()
    {
        dm = FindObjectOfType<DataManager>();

        targets = FindObjectsOfType<TargetBehaviour>();

        FaceNextTarget();
    }
    void Update()
    {
        ShootProjectile();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            FaceNextTarget();
        }
    }

    void ShootProjectile()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            Instantiate(bullet, transform.position, transform.rotation);

            
        }
    }

    private void FaceNextTarget()
    {
        int targetCount = targets.Length;

        for(int i = 0; i < targetCount; i++)
         {
            currentTargetIndex = (currentTargetIndex + 1) % targetCount;

            TargetBehaviour target = targets[currentTargetIndex];

            playerCamera.transform.LookAt(target.transform);

            transform.LookAt(target.transform);

            return;
         }
        
    }


   
    
}
