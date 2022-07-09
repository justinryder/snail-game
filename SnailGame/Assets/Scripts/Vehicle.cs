using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour 
{
    public float minSpeed;
	public float maxSpeed;

    public GameObject Explosion;

    public int MinPeopleContained;
    public int MaxPeopleContained;

	float speed;

	void Awake()
	{
		speed = Random.Range(minSpeed, maxSpeed);
		float temp = Random.Range(minSpeed, maxSpeed);
		if (temp < speed)
			speed = temp;
	}
	
	void Update()
    {
        transform.Translate(new Vector3(0,0,1) * speed * Time.deltaTime, Space.Self);
	}
}
