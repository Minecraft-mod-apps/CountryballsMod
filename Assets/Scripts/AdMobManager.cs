
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using System.Collections;
using GoogleMobileAds.Common;

public class AdMobManager : MonoBehaviour
{
     private string _interID = "ca-app-pub-2610580573633138/4902449994";
     //private string _interID = "ca-app-pub-3940256099942544/1033173712"; //test
     private string _rewardID = "ca-app-pub-2610580573633138/1154776671";
     //private string _rewardID = "ca-app-pub-3940256099942544/5224354917"; //test


     private InterstitialAd _interstitialAD;
     private RewardedAd _rewardedAD;
     private OpenAD _openAd;

     private void Start()
     {
         if(Application.systemLanguage == SystemLanguage.Russian)
         {
             Destroy(gameObject);
             return;
         }

         MobileAds.Initialize((arg1) => { 
             AppStateEventNotifier.AppStateChanged += state =>
               {
                   if(state == AppState.Foreground)
                      _openAd.Show();
               };});

         EventHandler.ShowInterAd.AddListener(ShowAD);
         EventHandler.ShowRewardedAd.AddListener(ShowRewardedAD);
         DontDestroyOnLoad(gameObject);
         InitID();
         _openAd = new OpenAD();
         OpenAD.LoadFailed.AddListener(ShowReserve);
         _openAd.LoadOpenAD();
         StartCoroutine(_openAd.ShowOpenAD());
     }

     private void ShowReserve()
     {
         StopAllCoroutines();
         StartCoroutine(ShowReserveInter());
     }

     private IEnumerator ShowReserveInter()
     {
         while (!_interstitialAD.IsLoaded())
         {
             yield return null;
         }
         EventHandler.LoadingIsEnd.Invoke();
         OpenAD.LoadFailed.RemoveAllListeners();
         _interstitialAD.Show();
     }

     public void InitID()
     {
         _interstitialAD = new InterstitialAd(_interID);
         _interstitialAD.OnAdClosed += OnAdClosedHandler;
         _interstitialAD.OnAdFailedToLoad += (arg1, arg2) => EventHandler.LoadingIsEnd.Invoke();
         LoadAD();

         _rewardedAD = new RewardedAd(_rewardID);
         LoadRewardedAD();
     }

     private void LoadAD()
     {
         AdRequest request = new AdRequest.Builder().Build();
         _interstitialAD.LoadAd(request);
     }

     private void LoadRewardedAD()
     {
         AdRequest rewardedRequest = new AdRequest.Builder().Build();
         _rewardedAD.LoadAd(rewardedRequest);

     }

     private void OnAdClosedHandler(object sender, EventArgs e)
     {
         LoadAD();
     }

     IEnumerator Downloader()
     {
        yield return new WaitForSeconds(.5f);
         EventHandler.StartLoadFile.Invoke();
         LoadRewardedAD();
     }

     public void ShowAD()
     {
         if (_interstitialAD != null)
         {
             if (!_interstitialAD.IsLoaded())
             {
                 LoadAD();
             }

             if (_interstitialAD.IsLoaded())
             {
                 _interstitialAD.Show();
             }
         }

     }

     public void ShowRewardedAD()
     {
         if (_rewardedAD != null)
         {
             if (_rewardedAD.IsLoaded())
             {
                 _rewardedAD.OnUserEarnedReward += (arg1, arg2) => StartCoroutine(Downloader());
                 _rewardedAD.Show();
                 return;
             }
         }
         StartCoroutine(Downloader());
     }
}
