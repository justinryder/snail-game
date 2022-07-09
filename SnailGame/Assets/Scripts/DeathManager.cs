using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathName
{
	public string name;
	public float timeLeft;
    
	
	public DeathName(string name, float timeLeft)
	{
		this.name = name;
		this.timeLeft = timeLeft;
	}
}

public class DeathManager : MonoBehaviour
{
    public GUIStyle style;

	public TextAsset firstNameFile;
	public TextAsset surNameFile;
	
	public float TimeToAddToDisplay;
	public float TimeInQueue;
	
	public int maxNamesOnDisplay; 
	
	public static int DeathCount;
	
	static List<string> firstNames;
	static List<string> surNames;

	public static List<string> allDeaths = new List<string>();
    static List<string> queueList = new List<string>();
    public static List<DeathName> displayList = new List<DeathName>();
	
	static float timeToAddToDisplay;
	static float timeInQueue;
	
	private bool peopleDead;

	void Awake()
	{
		if (GameObject.Find("DeathManager") != gameObject)
			Destroy(gameObject);
		DontDestroyOnLoad(this);
	}

	void Start()
	{
		firstNames = populateList(firstNameFile);
		surNames = populateList(surNameFile);
		
		timeInQueue = TimeInQueue;
		
		peopleDead = true;
	}
	
	void Update()
	{
		if (timeInQueue > 0)
		{
			timeInQueue -= Time.deltaTime;
		}
		else
		{
			if (queueList.Count > 0)
			{
				while( displayList.Count > maxNamesOnDisplay)
				{
					displayList.RemoveAt(displayList.Count - 1);
				}

				allDeaths.Add(queueList[0]);
				displayList.Insert(0, new DeathName(queueList[0], TimeToAddToDisplay));
				DeathCount++;
				
				queueList.RemoveAt(0);
				
				timeInQueue = TimeInQueue;
			}
		}
		
		for (int i = 0; i < displayList.Count; i++)
		{
			if (displayList[i].timeLeft > 0)
			{
				displayList[i].timeLeft -= Time.deltaTime;
			}
			else
			{
				displayList.Remove(displayList[i]);
			}
		}
	}
	
	List<string> populateList(TextAsset file)
	{
		string currentName = "";
		string fileText = file.text;
		
		List<string> newList = new List<string>();
		
		for (int i = 0; i < fileText.Length; i++)
		{
			if (fileText[i] != '\n')
			{
				currentName += fileText[i];
			}
			else
			{
				newList.Add(currentName);
				currentName = "";
			}
		}
		
		return newList;
	}
	
	public static void KillPeople(int min, int max)
	{
		int numOfDeaths = Random.Range(min, max);
		
		string surnameChoice = surNames[Random.Range(0, surNames.Count - 1)];

		for (int i = 0; i < numOfDeaths; i++)
		{
			queueList.Add(firstNames[Random.Range(0, firstNames.Count - 1)] + " " + surnameChoice);
		}
	}
	
	public static void KillPeople(int min, int max, bool isFamily)
	{
		int numOfDeaths = Random.Range(min, max);
		
		if (isFamily)
		{
			string surnameChoice = surNames[Random.Range(0, surNames.Count - 1)];
	
			for (int i = 0; i < numOfDeaths; i++)
			{
				queueList.Add(firstNames[Random.Range(0, firstNames.Count - 1)] + " " + surnameChoice);
			}
		}
		else
		{
			for (int i = 0; i < numOfDeaths; i++)
			{
				queueList.Add(firstNames[Random.Range(0, firstNames.Count - 1)] + " " + surNames[Random.Range(0, surNames.Count - 1)]);
			}
		}
	}
	
	void OnGUI()
	{
		for (int i = 0; i < displayList.Count; i++)
		{
            Vector2 sizeOfString = style.CalcSize(new GUIContent(displayList[i].name + " died."));
            GUI.Label(new Rect(Screen.width - sizeOfString.x, 0 + (i * (sizeOfString.y + sizeOfString.y / 4)), sizeOfString.x, sizeOfString.y), displayList[i].name + " died.", style);
		}

		if (Application.loadedLevelName == "Game")
		{
			if (DeathCount > 0)
			{
                Vector2 size = style.CalcSize(new GUIContent("Civilian Death Count: " + DeathCount));
                GUI.Label(new Rect(0, 0, size.x, size.y), "Civilian Death Count: " + DeathCount, style);
			}
		}
	}
}
