using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CutsceneManager : MonoBehaviour
{
	public List<Texture2D> imageList;
	private int currentImage;

	bool playingCutscene { get { return autoplayCutscene; } set { autoplayCutscene = value; currentImage = 0; } }
	public bool autoplayCutscene = false;
	
	void Start()
	{
		currentImage = 0;
	}
	
	void Update ()
	{
		if (playingCutscene)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (currentImage < imageList.Count - 1)
				{
					currentImage++;
				}
				else
				{
					playingCutscene = false;
					Application.LoadLevel("TrollvisScene");
				}
			}
		}
	}
	
	void OnGUI()
	{
		if (!playingCutscene)
		{
			if (Application.loadedLevelName == "Start")
			{
				if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 10, 100, 20), "Snails"))
					playingCutscene = true;
				if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 20, 100, 20), "Credits"))
					Application.LoadLevel("Credits");
				if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 20), "Quit"))
					Application.Quit();
			}
			if (Application.loadedLevelName == "Win")
			{
				if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 40, 100, 20), "Snails"))
					Application.LoadLevel("TrollvisScene");
				if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 10, 100, 20), "Main Menu"))
					Application.LoadLevel("Start");
				if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 20, 100, 20), "Credits"))
					Application.LoadLevel("Credits");
			}
		}
		
		if (playingCutscene && imageList.Count > 0)
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), imageList[currentImage]);
	}
}
