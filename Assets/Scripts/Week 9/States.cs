using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour
{
    //Define 3 states that the players animation can be set to

    private enum State //enums store data, position is named data unlike array index were value & index differ, stores different kinds of data
    {
        Idle,
        Walking,
        Jumping
    }

    //Variable for storing current state

    private State currentState; 

    
    void Start()
    {
        currentState = State.Idle;   //Player isn't moving on start, begin in idle state
    }

    // Update is called once per frame
    void Update()
    {
        HandleState(); //Method to handle current state

       if(Input.GetKeyDown(KeyCode.W)) //On W pressed change state to walking
        {
            ChangeState(State.Walking);
        }

       else if (Input.GetKeyDown(KeyCode.Space)) //On Space pressed change state to jumping
        {
            ChangeState(State.Jumping);
        }

       else if (Input.GetKeyDown(KeyCode.S)) //On S pressed change state to idle
        {
            ChangeState(State.Idle);
        }
    }

    private void HandleState() //Handles switching of commands
    {
        switch (currentState) 
        {
            case State.Idle:
                Debug.Log("Character is Idle"); //Idle animation command
                break;

            case State.Walking:
                Debug.Log("Character is Walking"); //Walking animation command
                break;

            case State.Jumping:
                Debug.Log("Character is Jumping"); //Jumping animation command
                break;

        }
    }

    private void ChangeState(State newState) //Recieves current state prints change.
    {
        currentState = newState;

        Debug.Log("Change state to: " + currentState);
    }
}
