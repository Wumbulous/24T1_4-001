using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAlg : MonoBehaviour
{
    private Target[] targets; //Stores array of all targets within the scene
    private int[] hpValues; //int array to store all target's hpValue

    // Start is called before the first frame update
    void Start()
    {
        targets = FindObjectsOfType<Target>(); //Fills array by finding all targets within the scene

        BubbleSort(); //Calls sorting method on start
    }

    void BubbleSort()
    {
        int n = targets.Length; //Stores length of targets array as int

        for(int i = 0; i < n -1; i++)//Loops through array until completely sorted, -1 to array length each time as the highest value will be in correct position each loop
        {
            for(int j = 0; j< n - i - 1; j++) //Loops through pairs until highest value is sorted
            {

              if(targets[j].GetHealthPoints() > targets[j + 1].GetHealthPoints()) //Compares hpValue of bubbled targets to see if they are in the right order. If the value to the left is greater than the one on the right continue.
              {
                  Target temp = targets[j]; //Stores current array index value temporarily 
                  targets[j] = targets[j + 1]; //Move smaller index value down by one
                  targets[j + 1] = temp; //Place temp up by one, sorting it correctly this loop
              }
            }
        }
    }

    public Target[] GetSortedHPValues() 
    {
        return targets; //Allows player to retrive the sorted targets list
    }
}
