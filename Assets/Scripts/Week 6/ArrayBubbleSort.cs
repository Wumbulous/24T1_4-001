using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayBubbleSort : MonoBehaviour
{
    int[] numberArray = { 5, 3, 8, 4, 2 }; //Declare array

  
    void Start()
    {
        Debug.Log("Original Array: " + ArrayToString(numberArray));  //Print array string in console

        BubbleSortArray(numberArray);

        Debug.Log("Sorted Array: " + ArrayToString(numberArray));
    }

    void BubbleSortArray(int[] array)
    {
        int n = array.Length; //Interger containing length of array

        for(int i = 0; i < n - 1; i++) //Loop through array until sorted shorten each loop as furthest right is sorted
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

    string ArrayToString(int[] array)
    {
        return string.Join(", ", array); //Convert array from int to string join with ", "
    }
}
