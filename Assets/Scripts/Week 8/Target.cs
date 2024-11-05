using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int healthPoints;

    public int GetHealthPoints()
    {
        return healthPoints;
    }
}
