using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int neededCoins = 1; 
    private int CollectedCoin = 0;
    private bool isPaused = false;

    
    public void AddCollectedCoin(int amount)
    {
        CollectedCoin += amount;
        if(CollectedCoin >= neededCoins)
        {
            SceneManager.LoadScene("You Win");
        }

    }
    void Update()
    {
        Pause();

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
