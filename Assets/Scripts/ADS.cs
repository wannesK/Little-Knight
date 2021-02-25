using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class ADS : MonoBehaviour, IUnityAdsListener
{
    string gameId = "4024933";
    string mySurfacingId = "Rewarded_Android";
    bool testMode = true;

    private ScoreManager scoreManager;
    // Initialize the Ads listener and service:
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
        scoreManager = GameObject.FindGameObjectWithTag("Data").GetComponent<ScoreManager>();
    }
    public void ShowInterstitialAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else
        {
            Debug.Log("Interstitial video is not ready at the moment! Please try again later!");
        }
    }

    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(mySurfacingId))
        {
            Advertisement.Show(mySurfacingId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (surfacingId == mySurfacingId)
        {
            if (showResult == ShowResult.Finished)
            {
                // Reward the user for watching the ad to completion.
                scoreManager.data.coin += 50;
                scoreManager.coinText.text = scoreManager.data.coin.ToString();
            }
        }
        
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
            Debug.Log("AD skipped");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == mySurfacingId)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}
