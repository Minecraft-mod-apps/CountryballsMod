using UnityEngine;
//using GoogleMobileAds.Api;
using Nanoded.AdMob.SingleAd;
using System;
using System.Collections;

public class AdMobManager : MonoBehaviour
{
    [SerializeField] private string _interstitialID;
    [SerializeField] private string _rewardedID;
    [SerializeField] private string _openAdID;
    private SingleInterstitialAd _interstitialAD;
    private SingleRewardedAd _rewardedAD;
    private SingleOpenAppAd _appOpenAD;

    private bool _isShowing = false;

    void Start()
    {
        EventHandler.AdIsShowing.Invoke();
        EventHandler.ShowRewarded.AddListener(() => EventHandler.StartModInstall.Invoke());

        // if (Application.systemLanguage == SystemLanguage.Russian)
        // {
        //     Destroy(this);
        //     return;
        // }
        //
        // _interstitialAD = new SingleInterstitialAd();
        // _rewardedAD = new SingleRewardedAd();
        // _appOpenAD = new SingleOpenAppAd();
        //
        //
        // EventHandler.ShowInter.AddListener(ShowInterstitialAd);
        // EventHandler.ShowRewarded.AddListener(ShowRewardedAd);
        //
        // MobileAds.Initialize((arg1) => { });
        //
        // _interstitialAD.Initialize(_interstitialID);
        // _interstitialAD.LoadAd();
        //
        // _rewardedAD.InitializeAndLoadAd(_interstitialID, OnRewardedAdClosed, OnUserEarnedReward: OnRewardedAdClosed);
        //
        // _appOpenAD.LoadAd(_openAdID, () =>
        // {
        //     StopAllCoroutines();
        //     StartCoroutine(ShowReserveAd());
        // });
        // StartCoroutine(ShowOpenApp());
    }

    // private void OnRewardedAdClosed(object sender, EventArgs e)
    // {
    //     EventHandler.StartModInstall.Invoke();
    //     _rewardedAD.InitializeAndLoadAd(_interstitialID, OnRewardedAdClosed, OnUserEarnedReward: OnRewardedAdClosed);
    // }
    //
    // IEnumerator ShowOpenApp()
    // {
    //     while(!_appOpenAD.IsValid())
    //     {
    //         yield return null;
    //     }
    //
    //     _appOpenAD.ShowAd();
    // }
    //
    // IEnumerator ShowReserveAd()
    // {
    //     if(_isShowing == false)
    //     {
    //         _isShowing = true;
    //         while(_interstitialAD.IsReady())
    //         {
    //             yield return null;
    //         }
    //         _interstitialAD.ShowAdWithReload();
    //     }
    //     EventHandler.AdIsShowing.Invoke();
    // }
    //
    // public void ShowInterstitialAd()
    // {
    //     _interstitialAD.ShowAdWithReload();
    // }
    //
    // public void ShowRewardedAd()
    // {
    //     _rewardedAD.ShowAd(() =>
    //     {
    //         EventHandler.StartModInstall.Invoke();
    //         _rewardedAD.InitializeAndLoadAd(_interstitialID, OnRewardedAdClosed, OnUserEarnedReward: OnRewardedAdClosed);
    //     });
    // }
}
