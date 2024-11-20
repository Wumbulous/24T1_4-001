using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAlg : MonoBehaviour
{
    private GameManagerAlg gameManager;
    private Target[] targets;
    private int currentTargetIndex = -1;

    [SerializeField] private Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManagerAlg>();
        targets = gameManager.GetSortedHPValues();
        FaceNextTarget();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
       {
           FaceNextTarget();
       }
    
    }

     private void FaceNextTarget()
     {

     int targetCount = targets.Length;

     for(int i = 0; i < targetCount; i++)
     {

       currentTargetIndex = (currentTargetIndex + 1) % targetCount;

       Target target = targets[currentTargetIndex];

       playerCamera.transform.LookAt(target.transform);
       return;
     }
    }
}
