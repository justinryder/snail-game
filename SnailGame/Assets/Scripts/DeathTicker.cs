using UnityEngine;
using System.Collections;

public class DeathTicker : MonoBehaviour
{
    public GUIStyle style;
	int lastIndex = -1;
	TickerText lastName;

	string titleText;

	void Start()
	{
		if (DeathManager.allDeaths.Count == 0)
			titleText = "It was for nothing...";
		else
			titleText = "You stole " + DeathManager.allDeaths.Count + " innocent lives.";
		DeathManager.displayList.Clear();
	}

	void OnGUI()
	{
		Vector2 titleSize = style.CalcSize(new GUIContent(titleText));
        GUI.Label(new Rect(Screen.width / 2 - titleSize.x / 2, 0, titleSize.x, titleSize.y), titleText, style);

		if (DeathManager.allDeaths.Count == 0)
			return;

		if (!lastName || lastName.rect.xMax < Screen.width)
		{
			lastIndex++;
			if (lastIndex >= DeathManager.allDeaths.Count)
				lastIndex = 0;
			lastName = gameObject.AddComponent<TickerText>();
			lastName.text = " " + DeathManager.allDeaths[lastIndex] + ", ";
			Vector2 lastNameSize = GUI.skin.label.CalcSize(new GUIContent(lastName.text));
			lastName.rect = new Rect(Screen.width, titleSize.y, lastNameSize.x, lastNameSize.y);
		}
	}

}

public class TickerText : MonoBehaviour
{
	public float scrollSpeed = 100;
	public Rect rect;
	public string text;

	void Update()
	{
		rect.x -= scrollSpeed * Time.deltaTime;
		if (rect.xMax < 0)
			Destroy(this);
	}

	void OnGUI()
	{
		GUI.Label(rect, text);
	}
}