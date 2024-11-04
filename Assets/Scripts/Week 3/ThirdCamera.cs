using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float sensitvity = 2.0f;
    public float heightOffset = 1.5f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    // Update is called once per frame
    void Update()
    {
        HandleCameraInput();
    }
    void HandleCameraInput()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitvity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitvity;

        rotationY += mouseX;

        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, -90, 90);

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);

    }
    void LateUpdate()
    {
        FollowTarget();
    }
    void FollowTarget()
    {
        Vector3 targetPosition = target.position - target.forward * distance + Vector3.up * heightOffset;
        transform.position = targetPosition;
    }

}

