using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        //Use for a loop display numbers from 1 to 10
        for (int i = 1; i <= 10; i++)
        {
            //Display current number in Unity console.
            Debug.Log("The current number is " + i);

        } 
    }
}
