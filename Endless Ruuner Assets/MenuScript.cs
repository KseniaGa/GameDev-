using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuScript : MonoBehaviour
{

	public void PlayButtn ()
	{
		SceneManager.LoadScene("MermaidGame");
	} 

	public void QuitGame()
	{
		Debug.Log("QUIT"); 
		Application.Quit(); 
	}
}
