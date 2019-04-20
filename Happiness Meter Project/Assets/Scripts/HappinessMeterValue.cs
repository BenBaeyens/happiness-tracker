using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HappinessMeterValue : MonoBehaviour {

	public Slider happinessSlider;

	private void Start()
	{
		if (PlayerPrefs.GetFloat("HappinessSlider") == 0)
			happinessSlider.value = 50;
		else
			happinessSlider.value = PlayerPrefs.GetFloat("HappinessSlider");
	}

	private void Update()
	{
		PlayerPrefs.SetFloat("HappinessSlider", happinessSlider.value);
	}
}
