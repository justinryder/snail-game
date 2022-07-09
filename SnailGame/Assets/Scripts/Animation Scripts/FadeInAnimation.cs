using UnityEngine;
using System.Collections;

public class FadeInAnimation : AnimationScript
{

	Texture2D image;
	Rect rect;

	public string imageResourcePath = "Textures/LoseScreen";

	public override void Start()
	{
		base.Start();

		image = Resources.Load(imageResourcePath) as Texture2D;
	}

	public override void Update()
	{
		base.Update();

		rect.x = Mathf.Lerp(Screen.width / 2, 0, percentDone);
		rect.y = Mathf.Lerp(Screen.height / 2, 0, percentDone);
		rect.width = Mathf.Lerp(0, Screen.width, percentDone);
		rect.height = Mathf.Lerp(0, Screen.height, percentDone);
	}

	public override void OnDestroy()
	{
		base.OnDestroy();

		Resources.UnloadAsset(image);
	}

	void OnGUI()
	{
		GUI.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, percentDone));
		GUI.DrawTexture(rect, image, ScaleMode.StretchToFill, true);
		GUI.color = Color.white;
	}

}
