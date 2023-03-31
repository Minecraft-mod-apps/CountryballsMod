// using GoogleMobileAds.Api;
// using GoogleMobileAds.Common;
using System;
using UnityEngine;

namespace Nanoded.AdMob.SingleAd
{
    public class SingleOpenAppAd
    {
        // private DateTime _loadTime;
        // private bool _isShowing;
        // private AppOpenAd _ad;
        // private string _id;
        //
        // /// <summary>
        // /// If more than four hours have passed since the ad was loaded return false.
        // /// </summary>
        // public bool IsValid() => (DateTime.UtcNow - _loadTime).TotalHours < 4 && _ad != null;
        //
        // /// <summary>
        // /// If current App Open Ad is empty(equals null) or is not valid loading App Open Ad. 
        // /// If loading ad success return true. 
        // /// </summary>
        // /// <returns></returns>
        // public bool LoadAd(string id, Action AdFailedToLoad = null)
        // {
        //     if(_id == null)
        //     {
        //         _id = id;
        //     }
        //     Debug.LogWarning(_id);
        //     if (!IsValid())
        //     {
        //         AdRequest request = new AdRequest.Builder().Build();
        //         AppOpenAd.LoadAd(id, ScreenOrientation.Portrait, request, (openAppAd, error) =>
        //         {
        //             if (error == null)
        //             {
        //                 _ad = openAppAd;
        //                 _loadTime = DateTime.UtcNow;
        //             }
        //             else
        //             {
        //                 AdFailedToLoad();
        //             }
        //         });
        //     }
        //     if (_ad != null) return true;
        //     return false;
        // }
        //
        // /// <summary>
        // /// If the ad is valid and not currently showing, it starts to show without additional event subscriptions. 
        // /// After the ad is closed, it is loaded again. 
        // /// If the ad is showing or out of date, the current ad will not be shown and the out of date ad will be updated.
        // /// </summary>
        // /// <param name="ad"></param>
        // public void ShowAd()
        // {
        //     if (IsValid() && !_isShowing)
        //     {
        //         _ad.OnAdDidDismissFullScreenContent += (arg1, arg2) =>
        //         {
        //             EventHandler.AdIsShowing.Invoke();
        //             _isShowing = false;
        //             _ad = null;
        //         };
        //         _ad.OnAdDidPresentFullScreenContent += (arg1, arg2) => _isShowing = true;
        //         _ad.OnAdFailedToPresentFullScreenContent += (arg1, arg2) => _ad = null;
        //         _ad.Show();
        //     }
        //     else
        //     {
        //         EventHandler.AdIsShowing.Invoke();
        //     }
        // }
        //
        // /// <summary>
        // /// If the ad is valid and not currently showing, it starts showing with all ad event subscriptions. 
        // /// After the ad is closed, you need call LoadOpenAppAd() if you want show ad again. 
        // /// If the ad is showing or if it is out of date, the current ad will not be shown and the out of date ad will be updated.
        // /// </summary>
        // /// <param name="OnAdDidDismiss">OnAdDidDismissFullScreenContent event subscriber</param>
        // /// <param name="OnAdDidPresent">OnAdDidPresentFullScreenContent event subscriber</param>
        // /// <param name="OnAdFailedToPresent">OnAdFailedToPresentFullScreenContent event subscriber</param>
        // /// <param name="OnAdDidRecordImpression">OnAdDidRecordImpression event subscriber</param>
        // /// <param name="OnPaidEvent">OnPaidEvent event subscriber</param>
        // public void ShowAd(EventHandler<EventArgs> OnAdDidDismiss = null, EventHandler<EventArgs> OnAdDidPresent = null,
        //     EventHandler<AdErrorEventArgs> OnAdFailedToPresent = null, EventHandler<EventArgs> OnAdDidRecordImpression = null,
        //     EventHandler<AdValueEventArgs> OnPaidEvent = null)
        // {
        //     if (IsValid() || !_isShowing)
        //     {
        //         _ad.OnAdDidDismissFullScreenContent += OnAdDidDismiss;
        //         _ad.OnAdDidPresentFullScreenContent += OnAdDidPresent;
        //         _ad.OnAdFailedToPresentFullScreenContent += OnAdFailedToPresent;
        //         _ad.OnAdDidRecordImpression += OnAdDidRecordImpression;
        //         _ad.OnPaidEvent += OnPaidEvent;
        //         _ad.Show();
        //     }
        //     EventHandler.AdIsShowing.Invoke();
        // }
    }
}
