//using GoogleMobileAds.Api;
using System;

namespace Nanoded.AdMob.SingleAd
{
    public class SingleInterstitialAd
    {
    //     private InterstitialAd _ad;
    //
    //     public bool IsReady() => _ad.IsLoaded();
    //     /// <summary>
    //     /// Initialize Interstitial Ad. Created new Interstitial Ad and assign to current Interstitial Ad.
    //     /// Without subscribing to ad events.
    //     /// </summary>
    //     /// <param name="id">Interstitial Id</param>
    //     public void Initialize(string id) => _ad = new InterstitialAd(id);
    //
    //     /// <summary>
    //     /// Initialize Interstitial Ad. Created new Interstitial Ad and assign to current Interstitial Ad.
    //     /// With sibscribing to ad events
    //     /// </summary>
    //     /// <param name="id">Interstitial Id</param>
    //     /// <param name="OnAdOpening">OnAdOpening event</param>
    //     /// <param name="OnAdFailedToShow">OnAdFailedToShow event</param>
    //     /// <param name="OnAdClosed">OnAdClosed event</param>
    //     /// <param name="OnAdDidRecordImpression">OnAdDidRecordImpression event</param>
    //     /// <param name="OnAdFailedToLoad">OnAdFailedToLoad event</param>
    //     /// <param name="OnAdLoaded">OnAdLoaded event</param>
    //     /// <param name="OnPaidEvent">OnPaidEvent event</param>
    //     public void Initialize(string id, EventHandler<EventArgs> OnAdOpening = null,
    //         EventHandler<AdErrorEventArgs> OnAdFailedToShow = null, EventHandler<EventArgs> OnAdClosed = null,
    //         EventHandler<EventArgs> OnAdDidRecordImpression = null, EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad = null,
    //         EventHandler<EventArgs> OnAdLoaded = null, EventHandler<AdValueEventArgs> OnPaidEvent = null)
    //     {
    //         _ad = new InterstitialAd(id);
    //         _ad.OnAdOpening += OnAdOpening;
    //         _ad.OnAdFailedToShow += OnAdFailedToShow;
    //         _ad.OnAdClosed += OnAdClosed;
    //         _ad.OnAdDidRecordImpression += OnAdDidRecordImpression;
    //         _ad.OnAdFailedToLoad += OnAdFailedToLoad;
    //         _ad.OnAdLoaded += OnAdLoaded;
    //         _ad.OnPaidEvent += OnPaidEvent;
    //     }
    //
    //     /// <summary>
    //     /// Create request and load Interstitial Ad.
    //     /// </summary>
    //     public void LoadAd()
    //     {
    //         if(_ad != null)
    //         {
    //             AdRequest request = new AdRequest.Builder().Build();
    //             _ad.LoadAd(request);
    //             _ad.OnAdFailedToLoad += (arg1, arg2) => EventHandler.AdIsShowing.Invoke();
    //         }
    //     }
    //
    //     /// <summary>
    //     /// Check if ad are loaded. If an ad is loaded, it shows it.
    //     /// After closing ad you need call LoadAd().
    //     /// </summary>
    //     /// <param name="ad"></param>
    //     public void ShowAd()
    //     {
    //         EventHandler.AdIsShowing.Invoke();
    //         if (_ad.IsLoaded()) _ad.Show();
    //     }
    //
    //     /// <summary>
    //     /// Check if ad are loaded. If an ad is loaded, it shows it, else ad will try load again.
    //     /// If ad failed to show or ad is closed current Interstitial Ad will load again.
    //     /// </summary>
    //     /// <param name="ad"></param>
    //     public void ShowAdWithReload()
    //     {
    //         EventHandler.AdIsShowing.Invoke();
    //         if (_ad.IsLoaded())
    //         {
    //             _ad.OnAdFailedToShow += (arg1, arg2) => LoadAd();
    //             _ad.OnAdClosed += (arg1, arg2) => LoadAd();
    //             _ad.Show();
    //         }
    //         else LoadAd();
    //
    //         EventHandler.AdIsShowing.Invoke();
    //     }
    }
}

