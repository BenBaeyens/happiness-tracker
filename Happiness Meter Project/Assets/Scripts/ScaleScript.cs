using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScaleScript : MonoBehaviour {

	public List<int> happiness;
	public List<string> times;
	public List<string> dates;

	public Text counter;
	public Text latestLog;
	public Text history;
	public Text okayText;

	

	private void Start()
	{
		happiness = new List<int>();
		times = new List<string>();
		dates = new List<string>();
		history.text = "-------[  -  ]-------" + System.Environment.NewLine + PlayerPrefs.GetString("historytext");
		for (int i = 0; i < PlayerPrefs.GetInt("HappinessTotal"); i++)
		{
			happiness.Insert(0, PlayerPrefs.GetInt("Happiness" + i));
			Debug.Log(happiness[i]);
		}

		if(happiness.Count >= 5 && happiness.Average() <= 5)
		{
			StartCoroutine(OkayMessage());
		}
		
		

	}

	private void Update()
	{
		counter.text = "You have logged your happiness for a total of " + happiness.Count + " time(s)!";
		if (happiness.Count > 0)
		{
			latestLog.text = dates[0] + "  at  " + times[0] + "  with a happiness of:  " + happiness[0];
		}
		
	}

	public void button1() {
		happiness.Insert(0, 1);

		PlayerPrefs.SetInt("HappinessTotal", happiness.Count);
		for (int i = 0; i < happiness.Count; i++)
		{
			PlayerPrefs.SetInt("Happiness" + i, happiness[i]);
		}
		PlayerPrefs.Save();

		times.Insert(0, System.DateTime.Now.ToString("hh:mm:ss"));
		dates.Insert(0, System.DateTime.Now.ToString("MM/dd/yyyy"));
		Addhistory();
		Debug.Log(times[0]);
		Debug.Log(dates[0]);
		Debug.Log(happiness[0]);
	
		
	}
	public void button2() {
		happiness.Insert(0, 2);
		PlayerPrefs.SetInt("HappinessTotal", happiness.Count);
		for (int i = 0; i < happiness.Count; i++)
		{
			PlayerPrefs.SetInt("Happiness" + i, happiness[i]);
		}
		PlayerPrefs.Save();
		times.Insert(0, System.DateTime.Now.ToString("hh:mm:ss"));
		dates.Insert(0, System.DateTime.Now.ToString("MM/dd/yyyy"));
		Addhistory();
	}
	public void button3() {
		happiness.Insert(0, 3);
		PlayerPrefs.SetInt("HappinessTotal", happiness.Count);
		for (int i = 0; i < happiness.Count; i++)
		{
			PlayerPrefs.SetInt("Happiness" + i, happiness[i]);
		}
		PlayerPrefs.Save();
		times.Insert(0, System.DateTime.Now.ToString("hh:mm:ss"));
		dates.Insert(0, System.DateTime.Now.ToString("MM/dd/yyyy"));
		Addhistory();
	}
	public void button4() {
		happiness.Insert(0, 4);
		PlayerPrefs.SetInt("HappinessTotal", happiness.Count);
		for (int i = 0; i < happiness.Count; i++)
		{
			PlayerPrefs.SetInt("Happiness" + i, happiness[i]);
		}
		PlayerPrefs.Save();
		times.Insert(0, System.DateTime.Now.ToString("hh:mm:ss"));
		dates.Insert(0, System.DateTime.Now.ToString("MM/dd/yyyy"));
		Addhistory();
	}
	public void button5() {
		happiness.Insert(0, 5);
		PlayerPrefs.SetInt("HappinessTotal", happiness.Count);
		for (int i = 0; i < happiness.Count; i++)
		{
			PlayerPrefs.SetInt("Happiness" + i, happiness[i]);
		}
		PlayerPrefs.Save();
		times.Insert(0, System.DateTime.Now.ToString("hh:mm:ss"));
		dates.Insert(0, System.DateTime.Now.ToString("MM/dd/yyyy"));
		Addhistory();
	}
	public void button6() {
		happiness.Insert(0, 6);
		PlayerPrefs.SetInt("HappinessTotal", happiness.Count);
		for (int i = 0; i < happiness.Count; i++)
		{
			PlayerPrefs.SetInt("Happiness" + i, happiness[i]);
		}
		PlayerPrefs.Save();
		times.Insert(0, System.DateTime.Now.ToString("hh:mm:ss"));
		dates.Insert(0, System.DateTime.Now.ToString("MM/dd/yyyy"));
		Addhistory();
	}
	public void button7() {
		happiness.Insert(0, 7);
		PlayerPrefs.SetInt("HappinessTotal", happiness.Count);
		for (int i = 0; i < happiness.Count; i++)
		{
			PlayerPrefs.SetInt("Happiness" + i, happiness[i]);
		}
		PlayerPrefs.Save();
		times.Insert(0, System.DateTime.Now.ToString("hh:mm:ss"));
		dates.Insert(0, System.DateTime.Now.ToString("MM/dd/yyyy"));
		Addhistory();
	}
	public void button8() {
		happiness.Insert(0, 8);
		PlayerPrefs.SetInt("HappinessTotal", happiness.Count);
		for (int i = 0; i < happiness.Count; i++)
		{
			PlayerPrefs.SetInt("Happiness" + i, happiness[i]);
		}
		PlayerPrefs.Save();
		times.Insert(0, System.DateTime.Now.ToString("hh:mm:ss"));
		dates.Insert(0, System.DateTime.Now.ToString("MM/dd/yyyy"));
		Addhistory();
	}
	public void button9() {
		happiness.Insert(0, 9);
		PlayerPrefs.SetInt("HappinessTotal", happiness.Count);
		for (int i = 0; i < happiness.Count; i++)
		{
			PlayerPrefs.SetInt("Happiness" + i, happiness[i]);
		}
		PlayerPrefs.Save();
		times.Insert(0, System.DateTime.Now.ToString("hh:mm:ss"));
		dates.Insert(0, System.DateTime.Now.ToString("MM/dd/yyyy"));
		Addhistory();
	}
	public void button10() {
		happiness.Insert(0, 10);
		PlayerPrefs.SetInt("HappinessTotal", happiness.Count);
		for (int i = 0; i < happiness.Count; i++)
		{
			PlayerPrefs.SetInt("Happiness" + i, happiness[i]);
		}
		PlayerPrefs.Save();
		times.Insert(0, System.DateTime.Now.ToString("hh:mm:ss"));
		dates.Insert(0, System.DateTime.Now.ToString("MM/dd/yyyy"));
		Addhistory();
	}

	void Addhistory()
	{
		if (happiness.Count > 0)
		{

			string historytext = dates[0] + "  at  " + times[0] + "  with a happiness of:  " + happiness[0] + "@" + history.text;
			historytext = historytext.Replace("@", System.Environment.NewLine);
			history.text = historytext;
			PlayerPrefs.SetString("historytext", historytext);
		}
	}


	IEnumerator OkayMessage()
	{
		okayText.text = "Hey, are you okay? Looks like you've been kinda down lately..." + System.Environment.NewLine + "<3 Ben";
		yield return new WaitForSeconds(10);
		okayText.text = "";
	}

}