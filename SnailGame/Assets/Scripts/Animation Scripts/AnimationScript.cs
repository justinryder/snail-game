using UnityEngine;
using System.Collections;

public abstract class AnimationScript : MonoBehaviour
{
	public delegate void AnimationEvent();
	public event AnimationEvent OnAnimationStart;
	public event AnimationEvent OnAnimationUpdate;
	public event AnimationEvent OnAnimationEnd;

	protected float startTime = 0;
	public float duration = 1;//seconds
	public bool isAnimating { get { return Time.time < startTime + duration; } }
	public float percentDone { get { return (Time.time - startTime) / duration; } }

	public virtual void Start()
	{
		startTime = Time.time;

		if (OnAnimationStart != null)
			OnAnimationStart();
	}

	public virtual void Update()
	{
		if (OnAnimationUpdate != null)
			OnAnimationUpdate();

		if (!isAnimating)
			Destroy(this);
	}

	public virtual void OnDestroy()
	{
		if (OnAnimationEnd != null)
			OnAnimationEnd();
	}

}
