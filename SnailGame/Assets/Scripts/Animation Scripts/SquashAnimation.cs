using UnityEngine;
using System.Collections;

public class SquashAnimation : AnimationScript
{

	Vector3 startScale;
	Vector3 endScale;
	public Vector3 deltaScale = new Vector3(2f, .5f, 2f);

	public override void Start()
	{
		startScale = transform.localScale;
		endScale = Vector3.Scale(startScale, deltaScale);

		base.Start();
	}

	public override void Update()
	{
		transform.localScale = Vector3.Lerp(startScale, endScale, percentDone);
		//Time.timeScale *= .9999f;//slows down time scale, maybe don't do this?

		base.Update();
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
	}

}
