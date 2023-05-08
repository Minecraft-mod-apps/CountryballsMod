using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Native
{
    public class NativeComponent : MonoBehaviour
    {
        [SerializeField] private Text _headlineText;
        [SerializeField] private Text _advertiserText;
        [SerializeField] private Text _buttonText;

        [SerializeField] private RawImage _iconImage;
        [SerializeField] private RawImage _choicesImage;

        public bool CanShow
        {
            get;
            set;
        }

        public void OnEnable()
        {
            if (!CanShow) gameObject.SetActive(false);
        }

        public GameObject SetHeadline(string headline)
        {
            _headlineText.text = headline;
            return _headlineText.gameObject;
        }

        public GameObject SetAdvertiser(string advertiser)
        {
            _advertiserText.text = advertiser;
            return _advertiserText.gameObject;
        }

        public GameObject SetButtonText(string buttonText)
        {
            _buttonText.text = buttonText;
            return _buttonText.gameObject;
        }

        public GameObject SetIcon(Texture2D icon)
        {
            _iconImage.texture = icon;
            return _iconImage.gameObject;
        }

        public GameObject SetChoices(Texture2D choices)
        {
            _choicesImage.texture = choices;
            return _choicesImage.gameObject;
        }
}
}

