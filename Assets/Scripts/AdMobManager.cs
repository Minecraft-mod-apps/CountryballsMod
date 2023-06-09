
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using System.Collections;

public class AdMobManager : MonoBehaviour
{
     private string _interID = "ca-app-pub-2610580573633138/4902449994";
     //private string _interID = "ca-app-pub-3940256099942544/1033173712"; //test
     private string _rewardID = "ca-app-pub-2610580573633138/1154776671";
     //private string _rewardID = "ca-app-pub-3940256099942544/5224354917"; //test


     private InterstitialAd _interstitialAD;
     private RewardedAd _rewardedAD;
     private OpenAD _openAd;

     private void Awake()
     {
         // if(Application.systemLanguage == SystemLanguage.Russian)
         // {
         //     Destroy(gameObject);
         //     return;
         // }
         
         EventHandler.ShowInterAd.AddListener(ShowAD);
         EventHandler.ShowRewardedAd.AddListener(ShowRewardedAD);
         MobileAds.Initialize((arg1) => { });
         InitID();
         _openAd = GetComponent<OpenAD>();
         _openAd.LoadFailed.AddListener(ShowReserve);
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
         while (!_interstitialAD.CanShowAd())
         {
             yield return null;
         }
         EventHandler.LoadingIsEnd.Invoke();
         _openAd.LoadFailed.RemoveAllListeners();
         _interstitialAD.Show();
     }

     public void InitID()
     {
         LoadAD();

         LoadRewardedAD();
     }

     private void LoadAD()
     {
         if (_interstitialAD != null)
         {
             _interstitialAD.Destroy();
             _interstitialAD = null;
         }
         
         AdRequest request = new AdRequest();
         InterstitialAd.Load(_interID, request, (ad, error) =>
         {
             if (error != null || ad == null)
             {
                 EventHandler.LoadingIsEnd.Invoke();
                 return;
             }
             _interstitialAD = ad;
             _interstitialAD.OnAdFullScreenContentClosed += LoadAD;
             _interstitialAD.OnAdFullScreenContentFailed += (arg) => LoadAD();
         });
     }

     private void LoadRewardedAD()
     {
         if (_rewardedAD != null)
         {
             _rewardedAD.Destroy();
             _rewardedAD = null;
         }
         
         AdRequest rewardedRequest = new AdRequest();
         RewardedAd.Load(_rewardID, rewardedRequest, (ad, error) =>
         {
             if (error != null || ad == null) return;
             _rewardedAD = ad;
             _rewardedAD.OnAdFullScreenContentFailed += error => LoadRewardedAD();
         });

     }

     IEnumerator Downloader()
     {
        yield return new WaitForSeconds(.5f);
         EventHandler.StartLoadFile.Invoke();
         LoadRewardedAD();
     }

     public void ShowAD()
     {
         if (_interstitialAD == null) return;
         if (!_interstitialAD.CanShowAd())
         {
             LoadAD();
             return;
         }
         _interstitialAD.Show();

     }

     public void ShowRewardedAD()
     {
         if (_rewardedAD != null)
         {
             if (_rewardedAD.CanShowAd())
             {
                 _rewardedAD.Show((reward =>
                 {
                     StartCoroutine(Downloader());
                 }));
                 return;
             }
         }
         StartCoroutine(Downloader());
     }
}
