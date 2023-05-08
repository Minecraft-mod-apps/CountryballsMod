// using System.Collections;
// using UnityEngine;
// using GoogleMobileAds.Api;
// using System;
// using UnityEngine.Events;
//
// public class OpenAD
// {
//     private const string _adID = "";
//     private static OpenAD _instance;
//     private AppOpenAd _openAD;
//     private bool _isShow;
//     private DateTime _loadTime;
//
//     public static UnityEvent LoadFailed = new UnityEvent();
//
//     public static OpenAD Instance()
//     {
//         if (_instance == null)
//         {
//             _instance = new OpenAD();
//         }
//         return _instance;
//     }
//
//     public bool IsAvailable()
//     {
//         return _openAD != null && (DateTime.UtcNow - _loadTime).TotalHours < 4;
//     }
//
//     public void LoadOpenAD()
//     {
//         if (_openAD == null)
//         {
//             AdRequest request = new AdRequest.Builder().Build();
//             AppOpenAd.LoadAd(_adID, ScreenOrientation.Portrait, request, ((ad, error) =>
//             {
//                 if (error == null)
//                 {
//                     _openAD = ad;
//                     _loadTime = DateTime.UtcNow;
//                 }
//                 else
//                 {
//                     LoadFailed.Invoke();
//                 }
//             }));
//         }
//     }
//
//     public IEnumerator ShowOpenAD()
//     {
//         while (!IsAvailable())
//         {
//             yield return null;
//             if (_isShow)
//             {
//                 break;
//             }
//         }
//         if (!_isShow)
//         {
//             _openAD.OnAdDidDismissFullScreenContent += (sender, e) =>
//             {
//                 _openAD = null;
//                 _isShow = false;
//                 EventHandler.LoadingIsEnd.Invoke();
//                 LoadOpenAD();
//             };
//
//             _openAD.OnAdDidPresentFullScreenContent += (sende, e) => _isShow = true;
//
//             _openAD.OnAdFailedToPresentFullScreenContent += (sender, e) =>
//             {
//                 _openAD = null;
//                 LoadOpenAD();
//             };
//             LoadFailed.RemoveAllListeners();
//             _openAD.Show();
//         }
//
//     }
// }