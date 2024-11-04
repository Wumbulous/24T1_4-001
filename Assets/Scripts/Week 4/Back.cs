using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
   void Update()
   {
	   BackUp();
   }
   void BackUp()
   {
	   if(Input.GetKeyDown(KeyCode.Escape))
	   {
		   SceneManager.LoadScene("Workshop Selector");
	   }

   }
}