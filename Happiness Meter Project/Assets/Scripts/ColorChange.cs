using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour {

	public Slider slider;
	private int counter;
	public Animator animator;

	public int MaxVal = 100;
	public Image Fill;
	public Color MaxValColor = Color.green;
	public Color MinValColor = Color.red;


	public void Start()
	{
		Fill.color = Color.Lerp(MinValColor, MaxValColor, (float)slider.value / MaxVal);
	}

	public void UpdateCounterBar()
	{
		Fill.color = Color.Lerp(MinValColor, MaxValColor, (float)slider.value / MaxVal);

	}
	
	public void SelectButton()
	{
		animator.SetTrigger("ButtonClicked");
	}

	public void DeselectButton()
	{
		animator.SetTrigger("ButtonUnclicked");
	}

}
