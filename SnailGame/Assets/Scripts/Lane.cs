using UnityEngine;
using System.Collections.Generic;

public class Lane : MonoBehaviour
{
    public List<Vehicle> mVehiclesToSpawn;

    public float MaxTimeToSpawn = 7;
    public float MinTimeToSpawn = 1;

    private float SpawnTimer = 0;
    private float CurrentSpawnTime = 0;

    void Start()
    {
        CurrentSpawnTime = Random.Range(MinTimeToSpawn, MaxTimeToSpawn);
    }

    // Update is called once per frame
    void Update() 
    {
        SpawnTimer += Time.deltaTime;

        if (SpawnTimer > CurrentSpawnTime)
        {
            CurrentSpawnTime = Random.Range(MinTimeToSpawn, MaxTimeToSpawn);
            GameObject.Instantiate(mVehiclesToSpawn[Random.Range(0, mVehiclesToSpawn.Count - 1)], transform.position, transform.rotation);
            SpawnTimer = 0;
        }
	}
}
