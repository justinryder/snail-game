using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreditsScreen : MonoBehaviour
{
	List<string> creditsList = new List<string>();
	// Use this for initialization
	void Start ()
	{
		creditsList.Add("~Designers~");
		creditsList.Add("Travis Constantino");
		creditsList.Add("Christina Aceves");
		creditsList.Add("");
		creditsList.Add("~Artists~");
		creditsList.Add("Xanth Veilleux");
		creditsList.Add("Erickson Paschke");
		creditsList.Add("");
		creditsList.Add("~Programmers~");
		creditsList.Add("Kyle Marchev");
		creditsList.Add("Steven Thorne");
		creditsList.Add("Justin Ryder");
		creditsList.Add("");
		creditsList.Add("~Sound~");
		creditsList.Add("Xycril - Elfman");
		creditsList.Add("Hox Vox - Kind_Titan");
		creditsList.Add("Celestial Aeon Project - MasqueradeE");
	}
	
	void OnGUI()
	{
		for (int i = 0; i < creditsList.Count; i++)
		{
			Vector2 size = GUI.skin.label.CalcSize(new GUIContent(creditsList[i]));
			GUI.Label(new Rect(Screen.width/2 - size.x/2, 0 + (i * (size.y + size.y/4)), size.x, size.y), creditsList[i]);
		}

		if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 20, 100, 20), "Main Menu")) Application.LoadLevel("Start");
	}
}
