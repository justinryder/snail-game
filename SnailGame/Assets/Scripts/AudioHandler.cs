using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioHandler : MonoBehaviour
{
	static AudioSource audioSource;
	static List<AudioClip> explosions = new List<AudioClip>();

	static AudioClip snailDeath;
	static AudioClip snailHarden;
	static AudioClip snailSoften;
	static AudioClip flower;

	public float explosionVolume = .3f;

	void Awake()
	{
		audioSource = gameObject.GetComponent<AudioSource>();

		foreach (AudioClip audioClip in Resources.LoadAll("Audio/Explosions"))
		{
			explosions.Add(audioClip);
		}

		snailDeath = Resources.Load("Audio/Snail/death") as AudioClip;
		snailHarden = Resources.Load("Audio/Snail/harden") as AudioClip;
		snailSoften = Resources.Load("Audio/Snail/soften") as AudioClip;
		flower = Resources.Load("Audio/Snail/flower") as AudioClip;
	}

	public static void PlayExplosion()
	{
		audioSource.PlayOneShot(explosions[Random.Range(0, explosions.Count)], 0.5f);
	}

	public static void PlaySnailDeath()
	{
		audioSource.PlayOneShot(snailDeath);
	}

	public static void PlaySnailHarden()
	{
		audioSource.PlayOneShot(snailHarden);
	}

	public static void PlaySnailSoften()
	{
		audioSource.PlayOneShot(snailSoften);
	}

	public static void PlayFlower()
	{
		audioSource.PlayOneShot(flower);
	}
}
