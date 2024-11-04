using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTNManager : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void NewLevelBtn(string newLevel) //take in string to identify next level
    {
        SceneManager.LoadScene(newLevel);   //command to open next level
    }


    public void ExitGameBtn() //custom function for exiting the game
    {
        Application.Quit();  //quit the running application
    }
}
