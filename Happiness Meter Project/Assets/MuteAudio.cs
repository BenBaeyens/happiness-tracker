using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour {

	public AudioSource audioSource;
	public AudioListener audioListener;

	public AudioClip buttonClick;
	public AudioClip swipeSound;
	public AudioClip valueChangeTick;
	public AudioClip flatButton;
	public AudioClip unmute;

	public Text muteButtonText;
	public Image muteButtonButton;

	Color32 redColor = new Color32(219, 141, 141, 255);
	Color32 greyColor = new Color32(255, 255, 255, 113);
	Color32 redText = new Color32(140, 0, 0, 255);
	Color32 greyText = new Color32(50, 50, 50, 255);

	bool isMuted;

	private void Start()
	{
	

		if (PlayerPrefs.GetString("isMuted") == "true") {
			isMuted = true;
			muteButtonText.text = "Unmute Audio";
			muteButtonButton.color = redColor;
			muteButtonText.color = redText;
		}
		else if (PlayerPrefs.GetString("isMuted") == "false")
		{
			isMuted = false;
			muteButtonButton.color = greyColor;
			muteButtonText.color = greyText;
		}
		else
		{
			isMuted = false;
			muteButtonButton.color = greyColor;
			muteButtonText.color = greyText;
		}
		
	}

	private void Update()
	{
		Debug.Log(isMuted);
	}

	public void MuteButton()
	{
		if(isMuted == false)
		{
			
			isMuted = true;
			PlayerPrefs.SetString("isMuted", "true");
			muteButtonText.text = "Unmute Audio";
			muteButtonButton.color = redColor;
			muteButtonText.color = redText;

		}
		else
		{
			muteButtonButton.color = greyColor;
			muteButtonText.color = greyText;
			isMuted = false;
			PlayerPrefs.SetString("isMuted", "false");
			muteButtonText.text = "mute Audio";
			audioSource.PlayOneShot(unmute);

			
		}
			
	}

	public void ButtonClick()
	{
		if(!isMuted)
			audioSource.PlayOneShot(buttonClick);
	}

	public void Swipe()
	{
		if(!isMuted)
			audioSource.PlayOneShot(swipeSound);
	}

	public void ValueChange()
	{
		if (!isMuted)
			audioSource.PlayOneShot(valueChangeTick);
	}

	public void FlatButton()
	{
		if (!isMuted)
			audioSource.PlayOneShot(flatButton);
	}
}
