using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nameiterator : MonoBehaviour
{
    private string[] people = { "Cloud", "Barret", "Tifa", "Aerith", "Sephiroth" };
    // Start is called before the first frame update
    void Start()
    {
        //Using foreach loop to iterate through aray of names
        foreach (string people in people)
        {
            Debug.Log("Name: " + people);
        }
    }
}