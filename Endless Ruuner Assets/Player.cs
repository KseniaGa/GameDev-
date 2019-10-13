using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	private Vector2 targetPos;
	public float increment = 2;
	public float speed ;

	public float maxHeight;
	public float minHeight;

	public int health = 5; 
   
    void Update()
    {

		if(health <= 0)
		{

			SceneManager.LoadScene("Menu");
			SceneManager.UnloadSceneAsync("MermaidGame"); 
		}

		transform.position = Vector2.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);



		if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
		{
			targetPos = new Vector2(transform.position.x, transform.position.y + increment);
			
		} else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
			
		{
			targetPos = new Vector2(transform.position.x, transform.position.y - increment);
			
		}
    }
}
