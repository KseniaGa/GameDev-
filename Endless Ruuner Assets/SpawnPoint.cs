using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	public GameObject Jelly;

	private void Start()
	{
		Instantiate(Jelly, transform.position, Quaternion.identity);
	}

}
