using UnityEngine;
using System.Collections.Generic;

public class Regret : MonoBehaviour
{
    public List<AudioClip> Regrets;

    public float MinTime = 7;
    public float MaxTime = 12;

    private float mCurrentClipTime = 0;
    private float mRegretTimer = 0;

    public AudioSource RegretSource;

	// Use this for initialization
	void Start () 
    {
        mCurrentClipTime = Random.Range(MinTime, MaxTime);
	}
	
	// Update is called once per frame
	void Update () 
    {
        mRegretTimer += Time.deltaTime;

        if (mRegretTimer > mCurrentClipTime)
        {
            RegretSource.clip = Regrets[Random.Range(0, Regrets.Count - 1)];//AudioSource.PlayClipAtPoint(Regrets[Random.Range(0, Regrets.Count - 1)], Camera.main.transform.position);
            RegretSource.Play();
            mRegretTimer = 0;
            mCurrentClipTime = Random.Range(MinTime, MaxTime);
        }
	}
}
