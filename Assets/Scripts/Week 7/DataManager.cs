using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManger : MonoBehaviour
{
    public List<TargetBehaviour> targets;
    public List<int> hpValues;

    // Start is called before the first frame update
    void Update()
    {
        targets = new List<TargetBehaviour>();

        hpValues = new List<int> {targets.Count};

        

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
                list[j + 1] = list[j]; //Shift greater element right

                j = j - 1; //Shift one step left  to compare key to next left element, until right spot is found.
            }
            list[j + 1] = key; //Insert key value in right spot.
        
        }
    }
   public List<int> GetSortedValues()
   {
       return hpValues;
   }
}
