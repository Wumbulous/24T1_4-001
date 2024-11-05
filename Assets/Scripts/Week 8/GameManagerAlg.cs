using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAlg : MonoBehaviour
{
    private Target[] targets;
    private int[] hpValues;

    // Start is called before the first frame update
    void Start()
    {
        targets = FindObjectsOfType<Target>();

        hpValues = new int[targets.Length];

        for(int i = 0; i < targets.Length; i++)
        {
            hpValues[i] = targets[i].GetHealthPoints();
        }

        BubbleSort(hpValues);
    }

    void BubbleSort(int[] array)
    {
        int n = array.Length;

        for(int i = 0; i < n -1; i++)
        {
            for(int j = 0; j< n - i - 1; j++)
            {

              if(array[j] < array[j + 1])
              {
                  int temp = array[j];
                  array[j] = array[j + 1];
                  array[j + 1] = temp;
              }
            }
        }
    }

    public int[] GetSortedHPValues()
    {
        return hpValues;
    }
}
