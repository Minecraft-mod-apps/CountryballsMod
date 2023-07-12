using System;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace Native
{
    public class QueueNative : MonoBehaviour
    {
        [SerializeField] private int _adCount;
        [SerializeField] private NativeComponent[] _nativeComponent;
        [SerializeField] private NativeComponent _missClickComponent;
        private Queue<NativeAd> _queueNativeAd;
        private const string _id = "ca-app-pub-2610580573633138/8937913836";
        //private const string _id = "ca-app-pub-3940256099942544/2247696110"; //test
        private string _nativeType = "regular";
        private int _currentNativeNumber = 0;
        private bool _canShow = false;
        
        private void Start()
        {
            if (Application.systemLanguage == SystemLanguage.Russian)
            {
                EventHandler.LoadEndNative.Invoke();
                foreach (var component in _nativeComponent)
                {
                    component.gameObject.SetActive(false);
                }
                _missClickComponent.gameObject.SetActive(false);
                Destroy(this);
                return;
            }

            foreach (var VARIABLE in _nativeComponent)
            {
                VARIABLE.gameObject.SetActive(false);
            }
            _queueNativeAd = new Queue<NativeAd>();
            CycleAdCreating(_adCount);
        }

        private void CycleAdCreating(int iterationCount)
        {
            for (var i = 0; i < iterationCount; i++)
            {
                LoadAd();
            }
            EventHandler.LoadEndNative.Invoke();
        }

        private void LoadAd()
        {
            var loader = new AdLoader.Builder(_id).ForNativeAd().Build();
            loader.OnNativeAdLoaded += NativeAdLoadedHandler;
            
            var request = new AdRequest.Builder().Build();
            loader.LoadAd(request);
        }

        private void NativeAdLoadedHandler(object sender, NativeAdEventArgs e)
        {
            _queueNativeAd.Enqueue(e.nativeAd);
            EventHandler.LoadEndNative.Invoke();
            _canShow = true;
            MobileAdsEventExecutor.ExecuteInUpdate(() =>
            {
                EventHandler.LoadEndNative.Invoke();
            });
        }

        public void RegisterAd(int i)
        {
            
            if(_queueNativeAd.Count <= 2) CycleAdCreating(3);
            
            if (_queueNativeAd.Count == 0) return;

            foreach (var VARIABLE in _nativeComponent)
            {
                VARIABLE.gameObject.SetActive(false);
            }
            
            _nativeType = "regular";
            
            var nativeAd = _queueNativeAd.Dequeue();
            
            var advertiser = _nativeComponent[i].SetAdvertiser(nativeAd.GetAdvertiserText());
            var a = nativeAd.RegisterAdvertiserTextGameObject(advertiser);

            var headline = _nativeComponent[i].SetHeadline(nativeAd.GetHeadlineText());
            var b = nativeAd.RegisterHeadlineTextGameObject(headline);

            var buttonText = _nativeComponent[i].SetButtonText(nativeAd.GetCallToActionText());
            var c = nativeAd.RegisterCallToActionGameObject(buttonText);

            var icon = _nativeComponent[i].SetIcon(nativeAd.GetIconTexture());
            var d = nativeAd.RegisterIconImageGameObject(icon);

            var choices = _nativeComponent[i].SetChoices(nativeAd.GetAdChoicesLogoTexture());
            var e = nativeAd.RegisterAdChoicesLogoGameObject(choices);

            _nativeComponent[i].gameObject.SetActive(true);
        }
        
        public void RegisterMissClickAd()
        {
            _missClickComponent.gameObject.SetActive(false);
            if(_queueNativeAd.Count <= 1) CycleAdCreating(2);
            
            if (_queueNativeAd.Count == 0) return;

            var nativeAd = _queueNativeAd.Dequeue();
            
            var advertiser = _missClickComponent.SetAdvertiser(nativeAd.GetAdvertiserText());
            var a = nativeAd.RegisterAdvertiserTextGameObject(advertiser);

            var headline = _missClickComponent.SetHeadline(nativeAd.GetHeadlineText());
            var b = nativeAd.RegisterHeadlineTextGameObject(headline);

            var buttonText = _missClickComponent.SetButtonText(nativeAd.GetCallToActionText());
            var c = nativeAd.RegisterCallToActionGameObject(buttonText);

            var icon = _missClickComponent.SetIcon(nativeAd.GetIconTexture());
            var d = nativeAd.RegisterIconImageGameObject(icon);

            var choices = _missClickComponent.SetChoices(nativeAd.GetAdChoicesLogoTexture());
            var e = nativeAd.RegisterAdChoicesLogoGameObject(choices);

            _missClickComponent.gameObject.SetActive(true);
            Debug.LogError("NATIVE MISSCLICK ENABLED");
        }
    }
}
