using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAlg : MonoBehaviour
{
    private GameManagerAlg gameManager; //Reference to game manager
    private Target[] targets; //Reference to aray of all targets in scene
    private int currentTargetIndex = -1; //Tracks the current index value player is looking at, starts at -1 as arrays start at 0

    [SerializeField] private Camera playerCamera; //Reference to camera in scene
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManagerAlg>(); //At start finds game manager in scene to reference
        targets = gameManager.GetSortedHPValues(); //Fills target array with the sorted hp values from the game manager
        FaceNextTarget(); //FaceNextTarget is called facing player at the targets at index 0 on game start
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space)) //If player presses the space key on any frame the FaceNextTarget method can be called.
       {
           FaceNextTarget();
       }
    
    }

     private void FaceNextTarget()
     {

     int targetCount = targets.Length; //Stores local integer at the length of the target array in order to keep within bounds

     for(int i = 0; i < targetCount; i++) 
     {

       currentTargetIndex = (currentTargetIndex + 1) % targetCount; //+1 to currentTargetIndex to make player look towards next target, % keeps amount within bounds of array, resets to 0 if exceeds.

       Target target = targets[currentTargetIndex]; // Stores local target refrence to target in currentTargetIndex index of target array

       playerCamera.transform.LookAt(target.transform); //Sets camera look at towards local target's transform
       return;
     }
    }
}
