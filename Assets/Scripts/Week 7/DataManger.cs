using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private TargetBehaviour[] targets;
    private int[] hpValues;

    // Start is called before the first frame update
    void Start()
    {
        targets = FindObjectsOfType<TargetBehaviour>();

        hpValues = new int[targets.Length];

    }

 

    void BubbleSortArray(int[] array)
    {
        int n = array.Length; //Interger containing length of array

        for(int i = 0; i < n - 1; i++) //Loop through array until sorted
        {
            for(int j = 0; j < n - i - 1; j++) //Compare pairs of adjacent elements
            {
                if (array[j] > array[j + 1]) //Compare if elements are in the wrong order
                {
                    int temp = array[j]; //Temporarily store array element

                    array[j] = array[j + 1]; //Move smaller element 

                    array[j + 1] = temp; //Place stored element


                }
            }
        }
    }
   public int[] GetSortedValues()
   {
       return hpValues;
   }
}
