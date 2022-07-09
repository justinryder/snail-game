using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndStory : MonoBehaviour
{
	public List<Texture2D> endStoryList;
	private int currentSlide;
	
	// Use this for initialization
	void Start ()
	{
		currentSlide = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (currentSlide < endStoryList.Count - 1)
				currentSlide++;
			else
				Application.LoadLevel("Win");
		}
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), endStoryList[currentSlide]);
	}
}
