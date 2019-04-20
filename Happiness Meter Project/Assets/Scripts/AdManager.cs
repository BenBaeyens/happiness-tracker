using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdManager : MonoBehaviour {

	public static AdManager instance;

	private string store_id = "3067819";

	private string video_ad = "video";
	private string rewarded_video_ad = "rewardedVideo";
	private string banner_ad = "bannerAd";

	public GameObject adNotLoadedText;


	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);

			if (Monetization.IsReady(banner_ad))
			{
				ShowAdPlacementContent ad = Monetization.GetPlacementContent(banner_ad) as ShowAdPlacementContent;
				if (ad != null)
				{
					ad.Show();
				}
			}
		}
	}

	private void Start()
	{
		Monetization.Initialize(store_id, false);
	}

	public void ShowVideo()
	{
		if (Monetization.IsReady(video_ad))
		{
			ShowAdPlacementContent ad = Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent;
			if (ad != null)
			{
				ad.Show();
			}
			else
			{
				StartCoroutine(AdNotReady());
			}
		}
	}

	public void ShowRewardVideo()
	{
		if (Monetization.IsReady(rewarded_video_ad))
		{
			ShowAdPlacementContent ad = Monetization.GetPlacementContent(rewarded_video_ad) as ShowAdPlacementContent;
			if (ad != null)
			{
				ad.Show();
			}
			else
			{
				StartCoroutine(AdNotReady());
			}
		}
	}

	IEnumerator AdNotReady()
	{
		adNotLoadedText.SetActive(true);
		yield return new WaitForSeconds(7);
		adNotLoadedText.SetActive(false);
	}
}
