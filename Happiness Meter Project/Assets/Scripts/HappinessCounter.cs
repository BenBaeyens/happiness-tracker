using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessCounter : MonoBehaviour {

	public Slider happinessSlider;
	public Text happinessCounterText;
	
	void Update () {
		happinessCounterText.text = (happinessSlider.value / 10).ToString();
	}
}
