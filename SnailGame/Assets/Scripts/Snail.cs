using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Snail : MonoBehaviour
{
    private bool mIsProtected = false;

	public bool isAlive { get; private set; }

    public int Health = 10000000;

    public float Speed = 1;

    public delegate void SnailDeath();
    public static event SnailDeath SnailDeathEvent;

    public GameObject SnailDeathEffect;

    public bool mStartedWalking = true;

    private float WalkStartTime = .5f;
    private float mWalkStartTimer = 0;

	Vector3 startLocation;
	public GameObject winTrigger;
	
	public List<Texture2D> endScreens;
	
	public float percentToFamily
	{
		get
		{
			return
				1 -
				(transform.position - winTrigger.transform.position).magnitude /
				(startLocation - winTrigger.transform.position).magnitude;
		}
	}

	void Awake() 
    {
		startLocation = transform.position;
		isAlive = true;
		if (animation.GetClipCount() > 0) animation.Play("Walk");
		//winTrigger = GameObject.Find("WinTrigger");
	}

	void OnDestroy()
	{

	}

	void OnGUI()
	{
		if (winTrigger)
		{
			GUI.Button(new Rect(Mathf.SmoothStep(Screen.width / 2, 0, percentToFamily),
								Screen.height - 20,
								Mathf.SmoothStep(0, Screen.width, percentToFamily),
								20),
						        "Hope");
		}
	}
	
	void Update() 
    {
		if (!isAlive)
			return;

		
        if (Input.anyKey)
        {
            if (!mIsProtected)
            {
                AudioHandler.PlaySnailHarden();
                animation.Play("In");
            }
            mIsProtected = true;
        }
        else
        {
            if (mIsProtected)
            {
                AudioHandler.PlaySnailSoften();
                animation.Play("Out");
                mWalkStartTimer = 0;
                mStartedWalking = false;
            }
			mIsProtected = false;
			transform.Translate(new Vector3(0, 0, 1) * Speed * Time.deltaTime, Space.Self);
        }

        mWalkStartTimer += Time.deltaTime;

        if (!mStartedWalking && mWalkStartTimer > WalkStartTime)
        {
            mStartedWalking = true;
            animation.Play("Walk");
        }
	}

    void OnTriggerEnter(Collider collider)
    {
		if (!isAlive)
			return;

		if (collider.name == "WinTrigger")
		{
			DontDestroyOnLoad(GameObject.Find("DeathManager"));
			Application.LoadLevel("EndStory");
		}

        Vehicle vehicleHit = collider.gameObject.GetComponent<Vehicle>();

		if (vehicleHit)
		{
            Attack(vehicleHit);
            return;
		}

        TankShell shell = collider.gameObject.GetComponent<TankShell>();

        if(shell != null)
        {
            Attack();
        }
    }

    public void Attack(Vehicle vehicleHit)
    {
        if (mIsProtected)
        {
            //put destruction here
            if (vehicleHit.Explosion)
            {
                GameObject.Instantiate(vehicleHit.Explosion, vehicleHit.transform.position, Quaternion.identity);
            }

            DeathManager.KillPeople(vehicleHit.MinPeopleContained, vehicleHit.MaxPeopleContained);
            vehicleHit.gameObject.AddComponent<ExplodeAnimation>();
			AudioHandler.PlayExplosion();
            Destroy(vehicleHit.gameObject, 10);
        }
        else
        {
            isAlive = false;

			animation.Stop();

            if (SnailDeathEvent != null)
                SnailDeathEvent();

            if (SnailDeathEffect != null)
                Instantiate(SnailDeathEffect, transform.position, Quaternion.identity);
        }
    }

    public void Attack()
    {
        if (!mIsProtected)
        {
            isAlive = false;

            if (SnailDeathEvent != null)
                SnailDeathEvent();

            if (SnailDeathEffect != null)
                Instantiate(SnailDeathEffect, transform.position, Quaternion.identity);
        }
    }
}
