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

    public UnityEvent LoadFailed = new UnityEvent();

    private void Start()
    {
        AppStateEventNotifier.AppStateChanged += state =>
        {
            if(state == AppState.Foreground) Show();
        };
    }

    public bool IsAvailable()
    {
        return _openAD != null;
    }

    public void LoadOpenAD()
    {
        if (_openAD != null)
        {
            _openAD.Destroy();
            _openAD = null;
        }
        AdRequest request = new AdRequest();
        AppOpenAd.Load(_adID, ScreenOrientation.Portrait, request, ((ad, error) =>
        {
            if (error != null || ad == null)
            {
                LoadFailed.Invoke();
                return;
            } 
            _openAD = ad;
            _openAD.OnAdFullScreenContentClosed += () =>
            {
                EventHandler.LoadingIsEnd.Invoke();
                LoadOpenAD();
            };
            _openAD.OnAdFullScreenContentFailed += adError => LoadOpenAD();
            _isShow = true;
        }));
    }

    public IEnumerator ShowOpenAD()
    {
        while (!IsAvailable())
        {
            yield return new WaitForSeconds(.1f);
        }
        Show();
    }

    private void Show()
    {
        LoadFailed.RemoveAllListeners();
        _openAD.Show();
    }
}