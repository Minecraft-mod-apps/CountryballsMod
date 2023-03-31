using UnityEngine;
using YandexMobileAds;
using YandexMobileAds.Base;

public class YandexAds : MonoBehaviour
{
    [SerializeField] private string _interId;
    private Interstitial _interstitialAd;
    private Interstitial _specialInterstitialAd;

    private void Start()
    {
        if(Application.systemLanguage != SystemLanguage.Russian)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        EventHandler.ShowInter.AddListener(ShowAd);
        EventHandler.ShowRewarded.AddListener(ShowRewarded);
        EventHandler.LoadingEnd.AddListener(() => _interstitialAd.Show());

        LoadInterstitial();
    }

    private void LoadInterstitial()
    {
        _interstitialAd?.Destroy();
        _interstitialAd = new Interstitial(_interId);
        var request = new AdRequest.Builder().Build();
        _interstitialAd.LoadAd(request);
        _interstitialAd.OnInterstitialFailedToLoad += (arg1, arg2) =>
        {
            EventHandler.AdIsShowing.Invoke();
        };
        _interstitialAd.OnInterstitialLoaded += (arg1, arg2) =>
        {
            EventHandler.AdIsShowing.Invoke();
        };
        _interstitialAd.OnInterstitialDismissed += (arg1, arg2) => LoadInterstitial();
        _interstitialAd.OnInterstitialFailedToShow += (arg1, arg2) => LoadInterstitial();
    }

    private void ShowAd()
    {
        if (_interstitialAd.IsLoaded())
        {
            _interstitialAd.Show();
        }
        else
        {
            LoadInterstitial();
        }
    }
    
    private void ShowRewarded()
    {
        ShowAd();
        EventHandler.StartModInstall.Invoke();
    }
}
