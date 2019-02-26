using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class GAMReward : MonoBehaviour
{
    private RewardBasedVideoAd rewardBasedVideoAd;
    
    // Start is called before the first frame update
    void Start()
    {
        setupRewardBasedVideoAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        var style = new GUIStyle();

        // Puts some basic buttons onto the screen.
        GUI.skin.button.fontSize = (int)(0.035f * Screen.width);
        var buttonWidth = 0.8f * Screen.width;
        var buttonHeight = 0.15f * Screen.height;
        var columnOnePosition = 0.1f * Screen.width;

        var requestRewardedRect = new Rect(
            columnOnePosition,
            0.05f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(requestRewardedRect, "Request\nRewarded Video"))
        {
            this.requestRewardBasedVideoAd();
        }

        var showRewardedRect = new Rect(
            columnOnePosition,
            0.225f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(showRewardedRect, "Show\nRewarded Video"))
        {
            this.showRewardBasedVideoAd();
        }
    }

    #region RewardBasedVideoAd setup

    private void setupRewardBasedVideoAd()
    {
        MobileAds.SetiOSAppPauseOnBackground(true);
        this.rewardBasedVideoAd = RewardBasedVideoAd.Instance;
        this.rewardBasedVideoAd.OnAdLoaded += this.handleRewardBasedVideoAdLoaded;
        this.rewardBasedVideoAd.OnAdFailedToLoad += this.handleRewardBasedVideoAdFailedToLoad;
        this.rewardBasedVideoAd.OnAdOpening += this.handleRewardBasedVideoAdOpening;
        this.rewardBasedVideoAd.OnAdStarted += this.handleRewardBasedVideoAdStarted;
        this.rewardBasedVideoAd.OnAdRewarded += this.handleRewardBasedVideoAdRewarded;
        this.rewardBasedVideoAd.OnAdCompleted += this.handleRewardBasedVideoAdCompleted;
        this.rewardBasedVideoAd.OnAdClosed += this.handleRewardBasedVideoAdClosed;
        this.rewardBasedVideoAd.OnAdLeavingApplication += this.handleRewardBasedVideoAdLeavingApplication;
    }

    #endregion

    #region RewardBasedVideoAd request

    private void requestRewardBasedVideoAd()
    {
        var adUnitID = String.Empty;
#if UNITY_EDITOR
        adUnitID = "unused";
#elif UNITY_ANDROID
        adUnitID = "/6499/example/rewarded-video";
#elif UNITY_IPHONE
        adUnitID = "/6499/example/rewarded-video";
#else
        adUnitID = "unexpected_platform";
#endif
        var request = new AdRequest.Builder().Build();
        this.rewardBasedVideoAd.LoadAd(request, adUnitID);
    }

    #endregion

    #region RewardBaseVideoAd show

    private void showRewardBasedVideoAd()
    {
        if (this.rewardBasedVideoAd.IsLoaded())
        {
            this.rewardBasedVideoAd.Show();
        }
        else
        {
            MonoBehaviour.print("Reward based video ad is not ready yet.");
        }
    }
    

    #endregion

    #region RewardBaseVideoAd callback handler 

    private void handleRewardBasedVideoAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoAdLoaded event received.");
    }

    private void handleRewardBasedVideoAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoAdFailedToLoad event received with message: " + args.Message);
    }

    private void handleRewardBasedVideoAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoAdOpening event received.");
    }

    private void handleRewardBasedVideoAdStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoAdStarted event received.");
    }

    private void handleRewardBasedVideoAdRewarded(object sender, Reward args)
    {
        var type = args.Type;
        var amount = args.Amount;
        MonoBehaviour.print("HandleRewardBasedVideoAdRewarded event received for" + amount + " " + type);
    }

    private void handleRewardBasedVideoAdCompleted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoAdCompleted event received.");
    }

    private void handleRewardBasedVideoAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoAdClosed event received.");
    }

    private void handleRewardBasedVideoAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoAdLeavingApplication event received.");
    }
 
    #endregion
}
