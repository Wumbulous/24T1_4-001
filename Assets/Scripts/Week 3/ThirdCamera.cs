using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamera : MonoBehaviour
{
    public Transform target;//Transform refrence used for player 
    public float distance = 5.0f;//Offset behind target
    public float sensitvity = 2.0f;//Sensitivity of mouse movement
    public float heightOffset = 1.5f;//Offset above target

    private float rotationX = 0.0f; //Stores camera rotation on x axis
    private float rotationY = 0.0f;//Stores camera rotation on Y axis

    // Update is called once per frame
    void Update()
    {
        HandleCameraInput();//Calls HandleCameraInput method every frame
    }

    void HandleCameraInput()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitvity; //Stores mouse movement on X axis according to sensitivity
        float mouseY = Input.GetAxis("Mouse Y") * sensitvity;//Stores mouse movement on Y axis according to sensitivity

         rotationY += mouseX;//Handles Y rotation by laying it on 2D X axis

         rotationX -= mouseY;//Handles X rotation by laying it on 2D Y axis

        rotationX = Mathf.Clamp(rotationX, -90, 90);//Clamps X rotation to keep it between -90 and 90

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);//Applies rotation to camera using calculated rotation movements

    }
    void LateUpdate()//Late Update is called immediately after every update method
    {
        FollowTarget();
    }
    void FollowTarget()
    {
        Vector3 targetPosition = target.position - target.forward * distance + Vector3.up * heightOffset; //Calculates camera offset by finding the distance between the player and camera then applies offset to keep at constant distance.
        transform.position = targetPosition;//Previous is applied to camera's world position
    }

}

