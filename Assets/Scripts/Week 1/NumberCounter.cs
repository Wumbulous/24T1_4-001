using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberCounter : MonoBehaviour
{
    public int targetNumber = 10;

    private int currentNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        //Using while loop to count from 1 to target number
        while (currentNumber <= targetNumber)
        {
            //Display current numvber in Unity console
            Debug.Log("Number: " + currentNumber);
            currentNumber++;
        }
    }
}