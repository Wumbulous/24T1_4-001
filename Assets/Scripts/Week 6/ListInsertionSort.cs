using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListInsertionSort : MonoBehaviour
{
    List<int> numberList = new List<int> { 7, 1, 9, 6, 0 }; //Declare List

    void Start()
    {
        Debug.Log("Original List: " + ListToString(numberList));

        InsertionSortList(numberList);

        Debug.Log("Sorted List: " + ListToString(numberList));
    }

    void InsertionSortList(List<int> list)
    {
        int n = list.Count; //Store number of elements in list

        for(int i = 1; i < n; i++) //Loop through & sort items in list, start out at 1 as element 0 is considered sorted
        {
            int key = list[i];  //Key to represent item currently trying to sort at element i

            int j = i - 1; //Store previous item

            while(j >=0 && list[j] > key) // If j is 0 or greater and greater than the key j is in the wrong position
            {
                list[j + 1] = list[j]; //Shift greater element right and position

                j = j - 1; //Shift to j original position
            }
            list[j + 1] = key; //Insert key value in right spot.
        
        }
    }

    string ListToString(List<int> list)
    {
        return string.Join(", ", list); //Convert list into string
    }
}
