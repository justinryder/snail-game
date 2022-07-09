using UnityEngine;
using System.Collections;

public class StartScreenCar : MonoBehaviour {
	
	
	public float spawnTimer = 3;
	float timer = 5;
	public GameObject car;
	
	GameObject carClone;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer+= 1 * Time.deltaTime;
		
		if(timer >= spawnTimer)
		{
			carClone = Instantiate(car, transform.position, transform.rotation) as GameObject;
			timer = 0;
		}
	}
}
