using System;
using System.Collections.Generic;
// using GoogleMobileAds.Api;
// using GoogleMobileAds.Common;
using UnityEngine;

namespace Native
{
    public class QueueNative : MonoBehaviour
    {
//         [SerializeField] private int _adCount;
//         [SerializeField] private NativeComponent _nativeComponent;
//         [SerializeField] private NativeComponent _missClickComponent;
//         private Queue<NativeAd> _queueNativeAd;
//         private const string _id = "";
//         private string _nativeType = "regular";
//
            private void Start()
            {
                EventHandler.LoadEndNative.Invoke();
            }

//         private void Start()
//         {
//             if (Application.systemLanguage == SystemLanguage.Russian)
//             {
//                 EventHandler.LoadEndNative.Invoke();
//                 _nativeComponent.gameObject.SetActive(false);
//                 _missClickComponent.gameObject.SetActive(false);
//                 Destroy(this);
//                 return;
//             }
//             
//             _queueNativeAd = new Queue<NativeAd>();
//             CycleAdCreating(_adCount);
//         }
//
//         private void CycleAdCreating(int iterationCount)
//         {
//             for (var i = 0; i < iterationCount; i++)
//             {
//                 LoadAd();
//             }
//             EventHandler.LoadEndNative.Invoke();
//         }
//
//         private void LoadAd()
//         {
//             if (_queueNativeAd.Count == 0)
//             {
//                 _nativeComponent.gameObject.SetActive(false);
//                 _missClickComponent.gameObject.SetActive(false);
//             }
//             var loader = new AdLoader.Builder(_id).ForNativeAd().Build();
//             loader.OnNativeAdClicked += NativeAdClickedHandler;
//             loader.OnNativeAdImpression += NativeAdImpressionHandler;
//             loader.OnAdFailedToLoad += NativeAdFailedToLoadHandler;
//             loader.OnNativeAdLoaded += NativeAdLoadedHandler;
//             
//             var request = new AdRequest.Builder().Build();
//             loader.LoadAd(request);
//         }
//
//         private void NativeAdClickedHandler(object sender, EventArgs e)
//         {
//             MobileAdsEventExecutor.ExecuteInUpdate(() =>
//             {
//                // AppMetrica.Instance.ReportEvent("Native click " + _nativeType);
//             });
//         }
//
//         private void NativeAdImpressionHandler(object sender, EventArgs e)
//         {
//             //MobileAdsEventExecutor.ExecuteInUpdate(() => AppMetrica.Instance.ReportEvent("Native show"));
//         }
//
//         private void NativeAdFailedToLoadHandler(object sender, AdFailedToLoadEventArgs e)
//         {
//             //MobileAdsEventExecutor.ExecuteInUpdate(() => AppMetrica.Instance.ReportEvent("Native failed to load"));
//         }
//
//         private void NativeAdLoadedHandler(object sender, NativeAdEventArgs e)
//         {
//             _queueNativeAd.Enqueue(e.nativeAd);
//             EventHandler.LoadEndNative.Invoke();
//             _nativeComponent.CanShow = true;
//             _missClickComponent.CanShow = true;
//             MobileAdsEventExecutor.ExecuteInUpdate(() =>
//             {
//                 EventHandler.LoadEndNative.Invoke();
//             });
//         }
//
//         public void RegisterAd()
//         {
//             if(_queueNativeAd.Count <= 1) CycleAdCreating(2);
//             
//             if (_queueNativeAd.Count == 0) return;
//
//             _nativeType = "regular";
//             
//             var nativeAd = _queueNativeAd.Dequeue();
//             
//             var advertiser = _nativeComponent.SetAdvertiser(nativeAd.GetAdvertiserText());
//             var a = nativeAd.RegisterAdvertiserTextGameObject(advertiser);
//
//             var headline = _nativeComponent.SetHeadline(nativeAd.GetHeadlineText());
//             var b = nativeAd.RegisterHeadlineTextGameObject(headline);
//
//             var buttonText = _nativeComponent.SetButtonText(nativeAd.GetCallToActionText());
//             var c = nativeAd.RegisterCallToActionGameObject(buttonText);
//
//             var icon = _nativeComponent.SetIcon(nativeAd.GetIconTexture());
//             var d = nativeAd.RegisterIconImageGameObject(icon);
//
//             var choices = _nativeComponent.SetChoices(nativeAd.GetAdChoicesLogoTexture());
//             var e = nativeAd.RegisterAdChoicesLogoGameObject(choices);
//
//             _nativeComponent.gameObject.SetActive(true);
//
//             var registered = a && b && c && d && e;
//             //AppMetrica.Instance.ReportEvent("Native is registered - " + registered);
//         }
//         
//         public void RegisterMissClickAd()
//         {
//             if(_queueNativeAd.Count <= 1) CycleAdCreating(2);
//             
//             if (_queueNativeAd.Count == 0) return;
//
//             _nativeType = "misclick";
//             
//             var nativeAd = _queueNativeAd.Dequeue();
//             
//             var advertiser = _missClickComponent.SetAdvertiser(nativeAd.GetAdvertiserText());
//             var a = nativeAd.RegisterAdvertiserTextGameObject(advertiser);
//
//             var headline = _missClickComponent.SetHeadline(nativeAd.GetHeadlineText());
//             var b = nativeAd.RegisterHeadlineTextGameObject(headline);
//
//             var buttonText = _missClickComponent.SetButtonText(nativeAd.GetCallToActionText());
//             var c = nativeAd.RegisterCallToActionGameObject(buttonText);
//
//             var icon = _missClickComponent.SetIcon(nativeAd.GetIconTexture());
//             var d = nativeAd.RegisterIconImageGameObject(icon);
//
//             var choices = _missClickComponent.SetChoices(nativeAd.GetAdChoicesLogoTexture());
//             var e = nativeAd.RegisterAdChoicesLogoGameObject(choices);
//
//             _missClickComponent.gameObject.SetActive(true);
//
//             var registered = a && b && c && d && e;
//             //AppMetrica.Instance.ReportEvent("Native is registered - " + registered);
//         }
//
//         private void OnApplicationPause(bool pauseStatus)
//         {
//             if (!pauseStatus) return;
//             _nativeComponent.gameObject.SetActive(false);
//             _missClickComponent.gameObject.SetActive(false);
//         }
     }
}
