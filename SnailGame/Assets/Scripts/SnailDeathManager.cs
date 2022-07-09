using UnityEngine;
using System.Collections;

public class SnailDeathManager : MonoBehaviour 
{
	public GameObject snailGameObject;
    private bool mPlayerHasDied = false;
    private bool snailisdead = true;

	void Awake()
	{
		if (!snailGameObject)
			snailGameObject = GameObject.Find("Snail");
	}

    void Start()
    {
        Snail.SnailDeathEvent += StartDeathProceedings;
    }

    void OnDestroy()
    {
        Snail.SnailDeathEvent -= StartDeathProceedings;
    }

    void Update()
    {
        
    }

	SquashAnimation squashAnimation;
    void StartDeathProceedings()
    {
		//don't keep adding animations on hit cause we already died
		if (mPlayerHasDied)
			return;

		mPlayerHasDied = true;

		squashAnimation = snailGameObject.AddComponent<SquashAnimation>();
		squashAnimation.duration = 1;//we can change the duration of an animation like this
		squashAnimation.OnAnimationEnd += HandleDeathSquashAnimationEnd;

		AudioHandler.PlayFlower();
    }

	FadeInAnimation fadeInAnimation;
	void HandleDeathSquashAnimationEnd()
	{
		if (squashAnimation)
			squashAnimation.OnAnimationEnd -= HandleDeathSquashAnimationEnd;
		
		fadeInAnimation = snailGameObject.AddComponent<FadeInAnimation>();
		fadeInAnimation.duration = 3;
		fadeInAnimation.OnAnimationEnd += HandleLoseScreenFadeInAnimationEnd;
	}

	void HandleLoseScreenFadeInAnimationEnd()
	{
		if (fadeInAnimation)
			fadeInAnimation.OnAnimationEnd -= HandleLoseScreenFadeInAnimationEnd;

		Application.LoadLevel("TrollvisScene");
	}

}
