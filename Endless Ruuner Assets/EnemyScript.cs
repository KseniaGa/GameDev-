using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour


{


	public int damage = 1;
	public float speed; 

	private void Update()
	{
		transform.Translate(Vector2.left*speed*Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			//Do damage 
			collision.GetComponent<Player>().health -= damage;
			Debug.Log(collision.GetComponent<Player>().health);
			Destroy(gameObject); 
			//Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();


		}
	}
}
