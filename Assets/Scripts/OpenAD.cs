using System;
using System.Collections;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.Events;

public class OpenAD : MonoBehaviour
{
    private const string _adID = "ca-app-pub-2610580573633138/8650123311";
    //private const string _adID = "ca-app-pub-3940256099942544/3419835294";//test
    private static OpenAD _instance;
    private AppOpenAd _openAD;
    private bool _isShow;
    private DateTime _appOpenExpireTime;

    public UnityEvent LoadFailed = new UnityEvent();

    // private void Start()
    // {
        // if(Application.systemLanguage == SystemLanguage.Russian)
        // {
        //     Destroy(gameObject);
        //     return;
        // }
        // AppStateEventNotifier.AppStateChanged += state =>
        // {
        //     if(state == AppState.Foreground) Show();
        // };
    // }

    // public bool IsAvailable()
    // {
    //     return _openAD != null;
    // }
    //
    // public void LoadOpenAD()
    // {
    //     if (_openAD != null)
    //     {
    //         _openAD.Destroy();
    //         _openAD = null;
    //     }
    //     AdRequest request = new AdRequest.Builder().Build();
    //     AppOpenAd.Load(_adID, ScreenOrientation.Portrait, request, ((ad, error) =>
    //     {
    //         if (error != null || ad == null)
    //         {
    //             LoadFailed.Invoke();
    //             return;
    //         } 
    //         _openAD = ad;
    //         _openAD.OnAdFullScreenContentClosed += () =>
    //         {
    //             EventHandler.LoadingIsEnd.Invoke();
    //             LoadOpenAD();
    //         };
    //         _openAD.OnAdFullScreenContentFailed += adError => LoadOpenAD();
    //         _isShow = true;
    //     }));
    // }
    //
    // public IEnumerator ShowOpenAD()
    // {
    //     while (!IsAvailable())
    //     {
    //         yield return new WaitForSeconds(.1f);
    //     }
    //     Show();
    // }
    //
    // private void Show()
    // {
    //     LoadFailed.RemoveAllListeners();
    //     _openAD.Show();
    // }

    #region NewAppOpen

    public void Start()
    {
        if(Application.systemLanguage == SystemLanguage.Russian)
        {
            Destroy(gameObject);
            return;
        }
        
        StartCoroutine(LoadAds());

        MobileAds.Initialize(null);

        AppStateEventNotifier.AppStateChanged += OnAppStateChanged;
    }

    IEnumerator LoadAds()
    {
        yield return new WaitForSeconds(3f);

        RequestAndLoadAppOpenAd();
    }
    
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddKeyword("unity-admob-sample")
            .Build();
    }
    
     public bool IsAppOpenAdAvailable
    {
        get
        {
            return (_openAD != null
                    && _openAD.CanShowAd());
        }
    }

    public void OnAppStateChanged(AppState state)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (state == AppState.Foreground)
            {
                ShowAppOpenAd();
            }
        });
    }

    public void RequestAndLoadAppOpenAd()
    {
        // destroy old instance.
        if (_openAD != null)
        {
            DestroyAppOpenAd();
        }

        // Create a new app open ad instance.
        AppOpenAd.Load(_adID, ScreenOrientation.Portrait, CreateAdRequest(),
            (AppOpenAd ad, LoadAdError loadError) =>
            {
                if (loadError != null)
                {
                    LoadFailed.Invoke();
                    return;
                }
                else if (ad == null)
                {
                    LoadFailed.Invoke();
                    return;
                }

                _openAD = ad;
                this._appOpenExpireTime = DateTime.Now;

                ad.OnAdFullScreenContentOpened += () =>
                {
                    LoadFailed.RemoveAllListeners();
                };
                ad.OnAdFullScreenContentClosed += () =>
                {
                    LoadFailed.RemoveAllListeners();
                    RequestAndLoadAppOpenAd();
                    EventHandler.LoadingIsEnd.Invoke();
                };
            });
    }

    public void DestroyAppOpenAd()
    {
        if (_openAD!= null)
        {
            _openAD.Destroy();
            _openAD = null;
        }
    }
    
    public IEnumerator ShowOpenAD()
    {
        while (!IsAppOpenAdAvailable)
        {
            yield return new WaitForSeconds(.1f);
        }
        ShowAppOpenAd();
    }

    public void ShowAppOpenAd()
    {
        if (!IsAppOpenAdAvailable)
        {
            return;
        }
        _openAD.Show();
    }

    #endregion
}

