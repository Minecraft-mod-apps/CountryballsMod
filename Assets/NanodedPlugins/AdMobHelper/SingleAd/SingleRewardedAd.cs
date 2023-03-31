//using GoogleMobileAds.Api;
using System;

namespace Nanoded.AdMob.SingleAd
{
    public class SingleRewardedAd
    {
        // private RewardedAd _ad;
        //
        // /// <summary>
        // /// Create and load Rewarded Ad.
        // /// With subscribing to ad events.
        // /// </summary>
        // /// <param name="id">Rewarded Id</param>
        // /// <param name="OnAdClosed">OnAdClosed event</param>
        // /// <param name="OnAdFailedToLoad">OnAdFailedToLoad event</param>
        // /// <param name="OnAdFailedToShow">OnAdFailedToShow event</param>
        // /// <param name="OnAdLoaded">OnAdLoaded event</param>
        // /// <param name="OnAdOpening">OnAdOpening event</param>
        // /// <param name="OnUserEarnedReward">OnUserEarnedReward event</param>
        // /// <param name="OnPaidEvent">OnPaidEvent event</param>
        // /// <param name="OnAdDidRecordImpression">OnAdDidRecordImpression event</param>
        // public void InitializeAndLoadAd(string id, EventHandler<EventArgs> OnAdClosed = null, 
        //     EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad = null, EventHandler<AdErrorEventArgs> OnAdFailedToShow = null,
        //     EventHandler<EventArgs> OnAdLoaded = null, EventHandler<EventArgs> OnAdOpening = null, EventHandler<Reward> OnUserEarnedReward = null,
        //     EventHandler<AdValueEventArgs> OnPaidEvent = null, EventHandler<EventArgs> OnAdDidRecordImpression = null)
        // {
        //     _ad = new RewardedAd(id);
        //     AdRequest request = new AdRequest.Builder().Build();
        //     _ad.LoadAd(request);
        //     _ad.OnAdClosed += OnAdClosed;
        //     _ad.OnAdFailedToLoad += OnAdFailedToLoad;
        //     _ad.OnAdFailedToShow += OnAdFailedToShow;
        //     _ad.OnAdLoaded += OnAdLoaded;
        //     _ad.OnAdOpening += OnAdOpening;
        //     _ad.OnUserEarnedReward += OnUserEarnedReward;
        //     _ad.OnPaidEvent += OnPaidEvent;
        //     _ad.OnAdDidRecordImpression += OnAdDidRecordImpression;
        // }
        //
        // /// <summary>
        // /// Checked if ad are loaded. If an ad is loaded, it shows it.
        // /// </summary>
        // public void ShowAd(Action NotLoaded)
        // {
        //     if (_ad.IsLoaded())
        //     {
        //         _ad.Show();
        //     }
        //     else
        //     {
        //         NotLoaded();
        //     }
        // }
    }
}

