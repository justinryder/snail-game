using UnityEngine;
using System.Collections;

public class TankTurret : MonoBehaviour 
{
    public Transform pivtotPoint;
    public Transform FirePoint;

    public Snail Snail;

    public float RotationSpeed = 1;

    public float FireInterval = 5;
    private float mFireTimer = 0;

    public GameObject MuzzleFlash;

    public GameObject ShellExplosion;
    public float ShellForce = 1000;
	
	public AudioSource Fire;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 VectorToSnail = Snail.transform.position - transform.position;
        Vector3 TurretVector = transform.forward;

        float Angle = Vector3.Angle(TurretVector, VectorToSnail);

        if (Vector3.Dot(transform.right, VectorToSnail) > 0)
        {
            transform.RotateAround(pivtotPoint.transform.position, new Vector3(0, 1, 0), RotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(pivtotPoint.transform.position, new Vector3(0, 1, 0), -RotationSpeed * Time.deltaTime);
        }

        if (Angle < 5)
        {
            mFireTimer += Time.deltaTime;
            if (mFireTimer > FireInterval)
            {
                if (MuzzleFlash != null)
                {
                    GameObject fire = GameObject.Instantiate(MuzzleFlash, FirePoint.position, transform.rotation) as GameObject;
                    fire.transform.LookAt(fire.transform.position + Vector3.down, transform.forward);
                }
                mFireTimer = 0;
                GameObject bullet = GameObject.Instantiate(ShellExplosion, FirePoint.position, transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce((Snail.transform.position - FirePoint.position).normalized * ShellForce);

                Fire.Play();
            }
        }
	}
}
