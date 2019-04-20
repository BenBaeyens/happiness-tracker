using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using UnityEngine.EventSystems;


public class AddEntryNew : MonoBehaviour
{

	ButtonOnClick buttononclick;
	public Slider happinessCountSlider; // Slider for the happiness count when submitting
	public InputField happinessNoteField; // Inputfield for the happiness note left by user when submitting

	public List<string> happinessNote; // The note left by user when submitting
	public List<float> happinessCount; // The current happiness count when submitting
	public List<string> logDate; // The time and date of the submission

	public Transform historyObject;
	public Transform historyParent;

	private bool isRemovingEntry;

	#region Date & Time
	int dateYear;
	int dateMonth;
	int dateDay;

	int dateHour;
	int dateMinute;
	int dateSecond;
	#endregion

	private void Start()
	{
		historyParent = GameObject.FindGameObjectWithTag("HistoryParent").GetComponent<Transform>();
		happinessNote = new List<string>();
		happinessCount = new List<float>();
		logDate = new List<string>();

		//historyParent.transform.position = new Vector3(historyParent.transform.position.x, historyParent.transform.position.y, 1);
	
		string tempcount = PlayerPrefs.GetString("HappinessCount");


		if (tempcount.Length == 0) {
			Debug.Log("This shit don't contain no values chief.");
		}
		else {
			Debug.Log("Adding Old history");
			float[] tempcountArray = tempcount.Split('*').Select(Convert.ToSingle).ToArray();
			for (int i = 0; i <= tempcountArray.Length - 1; i++)
			{
				happinessCount.Add(tempcountArray[i]);
			}

			string tempdate = PlayerPrefs.GetString("LogDate");
			string[] tempdateArray = tempdate.Split('*');
			for (int i = 0; i <= tempdateArray.Length - 1; i++)
			{
				logDate.Add(tempdateArray[i]);
			}

	
			string tempnote = PlayerPrefs.GetString("HappinessNote");
			string[] tempnoteArray = tempnote.Split('*');
			for (int i =  0; i <= tempnoteArray.Length - 1; i++)
			{
				happinessNote.Add(tempnoteArray[i]);
			}
		

		
			
		}
		AddOldHistory();

		Debug.Log(PlayerPrefs.GetString("HappinessCount"));

	}
	public void Entry()
	{
		dateYear = System.DateTime.Now.Year;
		dateMonth = System.DateTime.Now.Month;
		dateDay = System.DateTime.Now.Day;

		dateHour = System.DateTime.Now.Hour;
		dateMinute = System.DateTime.Now.Minute;
		dateSecond = System.DateTime.Now.Second;

		happinessNote.Add(happinessNoteField.text);


		happinessNoteField.text = "";
		happinessCount.Add(happinessCountSlider.value / 10);
		logDate.Add( (dateYear + "/" + dateMonth + "/" + dateDay + "@" + dateHour + ":" + dateMinute + ":" + dateSecond));

		DataSave();

		AddHistory();

	}

	private void DataSave()
	{
		string tempcount = "";

		for (int i = 0; i < happinessCount.Count; i++)
		{
			if (i != happinessCount.Count - 1)
				tempcount += happinessCount[i].ToString() + '*';
			else
				tempcount += happinessCount[i].ToString();
		}


		string tempnote = "";

		for (int i = 0; i < happinessNote.Count; i++)
		{
			if (i != happinessNote.Count - 1)
				tempnote += happinessNote[i] + '*';
			else
				tempnote += happinessNote[i];
		}


		string tempdate = "";

		for (int i = 0; i < logDate.Count; i++)
		{
			if (i != logDate.Count - 1)
				tempdate += logDate[i] + '*';
			else
				tempdate += logDate[i];
		}


		PlayerPrefs.SetString("HappinessCount", tempcount);
		PlayerPrefs.SetString("HappinessNote", tempnote);
		PlayerPrefs.SetString("LogDate", tempdate);
	}

	public void AddHistory()
	{
		historyParent.gameObject.SetActive(true);
		Instantiate(historyObject, new Vector2(0, -9.7f), Quaternion.identity, historyParent);
		Text historyText = GameObject.FindGameObjectWithTag("HistoryText").GetComponent<Text>();
		historyText.tag = "Untagged";
		historyText.name = "historyText+" + (happinessCount.Count - 1).ToString();

		InputField historyNote = GameObject.FindGameObjectWithTag("HistoryNote").GetComponent<InputField>();
		historyNote.tag = "Untagged";

		historyText.text = logDate[logDate.Count - 1].Replace("@", " at ") + ", with a happiness of: " + happinessCount[happinessCount.Count - 1];
		historyNote.text = happinessNote[happinessNote.Count - 1];

		historyParent.transform.position = new Vector2(historyParent.position.x, historyParent.position.y - .5f);
	
		historyNote.gameObject.SetActive(false);

	}

	public void AddOldHistory()
	{
		if (happinessCount.Count == 0)
		{
			print("There are no previous logs");
		}
		else
		{
			Debug.Log(happinessCount.Count);
				for (int i = 0; i <= happinessCount.Count - 1; i++)
			{

				Instantiate(historyObject, new Vector3(0, -9.7f, 90f), Quaternion.identity, historyParent);
				Text historyText = GameObject.FindGameObjectWithTag("HistoryText").GetComponent<Text>();
				historyText.tag = "Untagged";
				historyText.name = "historyText+" + (i).ToString();

				InputField historyNote = GameObject.FindGameObjectWithTag("HistoryNote").GetComponent<InputField>();
				
				historyNote.tag = "Untagged";
				historyText.text = logDate[i].Replace("@", " at ") + ", with a happiness of: " + happinessCount[i];
				historyNote.text = happinessNote[i];


				historyParent.transform.position = new Vector2(historyParent.position.x, historyParent.position.y - .5f);
				
				historyNote.gameObject.SetActive(false);
				
		}

		}

	}
	public void AfterRemoveAddOldHistory()
	{
		if (happinessCount.Count == 0)
		{
			print("There are no previous logs");
		}
		else
		{
			Debug.Log(happinessCount.Count);
			for (int i = 0; i <= happinessCount.Count - 1; i++)
			{

				Instantiate(historyObject, new Vector3(0, 3.71f, 90f), Quaternion.identity, historyParent);
				Text historyText = GameObject.FindGameObjectWithTag("HistoryText").GetComponent<Text>();
				historyText.tag = "Untagged";
				historyText.name = "historyText+" + (i).ToString();

				InputField historyNote = GameObject.FindGameObjectWithTag("HistoryNote").GetComponent<InputField>();

				historyNote.tag = "Untagged";
				historyText.text = logDate[i].Replace("@", " at ") + ", with a happiness of: " + happinessCount[i];
				historyNote.text = happinessNote[i];


				historyParent.transform.position = new Vector2(historyParent.position.x, historyParent.position.y - .5f);

				historyNote.gameObject.SetActive(false);

			}

		}


		if (isRemovingEntry)
			isRemovingEntry = false;

	}



	public void RemoveEntry()
	{
		Debug.Log("attempting removing entry");

		int tempnumber = int.Parse(EventSystem.current.currentSelectedGameObject.transform.parent.name.Substring(12));
		Debug.Log(int.Parse(EventSystem.current.currentSelectedGameObject.transform.parent.name.Substring(12)));

		happinessNote.RemoveAt(tempnumber);
		happinessCount.RemoveAt(tempnumber);
		logDate.RemoveAt(tempnumber);

		foreach (Transform child in historyParent)
		{
			Destroy(child.gameObject);
		}

		isRemovingEntry = true;
		AfterRemoveAddOldHistory();
		DataSave();
	
	
		Debug.Log("done");

	}


	public void ResetPlayerPrefs()
	{
		PlayerPrefs.SetString("HappinessCount", null);
		PlayerPrefs.SetString("HappinessNote", null);
		PlayerPrefs.SetString("LogDate", null);
	}

	public void DebugTest()
	{
		Debug.LogWarning("-- Commencing Debug -- ");
		// Insert debug.log function here to test errors
		Debug.LogWarning("-- Debugging complete --");
	}
}
