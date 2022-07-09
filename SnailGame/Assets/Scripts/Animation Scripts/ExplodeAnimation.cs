using UnityEngine;
using System.Collections;

public class ExplodeAnimation : AnimationScript
{
	public float force = 25f;
	public float spinSpeed = 100f;

	//children auto-deleted
	GameObject smokeTrail;

	//non-children must delete
	GameObject fire;
	GameObject flame;

	Vector3 forceDirection;

	public override void Start()
	{
		duration = 10;

		base.Start();

		forceDirection = new Vector3((1 - 2 * Random.value) * force, Random.value * force, (1 - 2 * Random.value) * force);

		if (!GetComponent<Rigidbody>()) gameObject.AddComponent<Rigidbody>();
		GetComponent<Rigidbody>().AddForce(forceDirection, ForceMode.Impulse);
		GetComponent<Rigidbody>().AddTorque(Random.value * spinSpeed, Random.value * spinSpeed, Random.value * spinSpeed, ForceMode.Impulse);

		smokeTrail = Instantiate(Resources.Load("Particles/Smoke/Smoke Trail")) as GameObject;
		smokeTrail.transform.parent = transform;
		smokeTrail.transform.localPosition = Vector3.zero;
		// TODO: replace with new particle system
		// ParticleEmitter smokeTrailParticleEmitter = smokeTrail.GetComponent<ParticleEmitter>();
		// smokeTrailParticleEmitter.minSize = 10;
		// smokeTrailParticleEmitter.maxSize = 10;

		fire = Instantiate(Resources.Load("Particles/Fire/Fire1")) as GameObject;
		fire.transform.position = transform.position;

		flame = Instantiate(Resources.Load("Particles/Fire/Flame")) as GameObject;
		flame.transform.LookAt(transform, -forceDirection);
	}

	public override void Update()
	{
		base.Update();

		if (flame) flame.transform.position = transform.position;
	}

	public override void OnDestroy()
	{
		base.OnDestroy();

		Destroy(fire);
		Destroy(flame);
	}
	
}
