using UnityEngine;
using System.Collections;

public class MuzzleFlash : MonoBehaviour 
{
    public GameObject Fire;

	// Use this for initialization
	void Start ()
    {
        GameObject fire = GameObject.Instantiate(Fire, transform.position, transform.rotation) as GameObject;

        GameObject.Destroy(gameObject, 1);
        GameObject.Destroy(fire, 5);
	}
}
