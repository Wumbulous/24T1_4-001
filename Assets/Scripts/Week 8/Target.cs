using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int healthPoints; //Private integer used to assign health value to targets for sorting, serialized in editor

    public int GetHealthPoints() //Method used to retrive a target's helath point value
    {
        return healthPoints;
    }
}
