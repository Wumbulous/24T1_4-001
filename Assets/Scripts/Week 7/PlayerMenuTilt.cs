using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuTilt : MonoBehaviour
{
    public float rotationRateSide = 1.0f; //Controll speed of tilt

    private float xRot;               // Store xRotation

    public float rightX;             // Set right xoffset to change directions

    public float leftX;              // Set left xoffset to change direction

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, rotationRateSide * Time.deltaTime); //rotate on right vector according to speed and time

        xRot = transform.rotation.x * 100; //set to local rotation

        SideTilt();

    }
    void SideTilt()
    {
        if (xRot > rightX)
        {
            rotationRateSide *= -1; //if X > rightX change rotation direction

        }

        if (xRot < leftX) //if X < leftX change Direction
        {
            rotationRateSide *= -1;
        }
    }
}