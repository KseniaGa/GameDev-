using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	public GameObject[] JellyPatterns;
	private float timeBtwSpwn;
	public float startTimeBtwSpwn;
	public float decreaseTime;
	public float minTime = 0.65f;


	// Start is called before the first frame update
	

    // Update is called once per frame
    void Update()
    {
        if(timeBtwSpwn <= 0)
		{
			int rnd = Random.Range(0, JellyPatterns.Length);
			Instantiate(JellyPatterns[rnd], transform.position, Quaternion.identity);
			timeBtwSpwn = startTimeBtwSpwn;

			if(startTimeBtwSpwn <= minTime)
				startTimeBtwSpwn -= decreaseTime; 
		}
		else
		{
			timeBtwSpwn -= Time.deltaTime; 
		}
    }
}
