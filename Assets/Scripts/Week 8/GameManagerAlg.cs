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

        BubbleSort();
    }

    void BubbleSort()
    {
        int n = targets.Length;

        for(int i = 0; i < n -1; i++)
        {
            for(int j = 0; j< n - i - 1; j++)
            {

              if(targets[j].GetHealthPoints() > targets[j + 1].GetHealthPoints())
              {
                  Target temp = targets[j];
                  targets[j] = targets[j + 1];
                  targets[j + 1] = temp;
              }
            }
        }
    }

    public Target[] GetSortedHPValues()
    {
        return targets;
    }
}
