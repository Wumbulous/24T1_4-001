using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//library used here to load new scenes

public class GameManager : MonoBehaviour
{
    public int neededCoins = 1; //Adjustable integer used to set the amount of coins needed to win
    private int CollectedCoin = 0;//integer used to keep track on amount of coins player must collect to win
    private bool isPaused = false; //boolean used to keep track of if game is paused or not


    public void AddCollectedCoin(int amount)//Method called upon player colliding with coin recieves +1
    {
        CollectedCoin += amount;//Adds 1 to collected coin amount
        if (CollectedCoin >= neededCoins)//If player has collected the same amount of coins than is required send them to the win screen
        {
            SceneManager.LoadScene("You Win");
        }

    }
    void Update()
    {
        Pause();//Calls pause method every frame

    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.P)) //Checks input for toggle
        {
            if(isPaused) // Checks if Pause is true
            {
                Time.timeScale = 1.0f; //Unpauses
            }
            else // Checks if Pause is false
            {
                Time.timeScale = 0f; // Pause Game

            }
            isPaused = !isPaused; // Toggles Bool
        }
    }
}
