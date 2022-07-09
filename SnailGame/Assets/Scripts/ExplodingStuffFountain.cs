using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplodingStuffFountain : MonoBehaviour
{

	List<GameObject> stuff = new List<GameObject>();

	public float spawnChance = .1f;

	void Awake()
	{
		foreach (GameObject go in Resources.LoadAll("Prefabs/ExplodingCredits"))
			stuff.Add(go);
	}
	
	void Update()
	{
		if (Random.value < spawnChance)
		{
			GameObject go = Instantiate(stuff[Random.Range(0, stuff.Count)]) as GameObject;
			if (go.audio) Destroy(go.audio);
			if (go.animation) Destroy(go.animation);
			Snail snail = go.GetComponent<Snail>();
			if (snail) Destroy(snail);
			TankTurret tankTurret = go.GetComponentInChildren<TankTurret>();
			if (tankTurret) Destroy(tankTurret);
			go.AddComponent<ExplodeAnimation>();
		}
	}
}
