using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using TMPro;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Image[] _loadingImages;
    [SerializeField] private float _slideTime;
    [SerializeField] private TextMeshProUGUI _loadingText;
    [SerializeField] private GameObject _nextScreen;
    private Sequence _sequence;
    private float _currentDelay = 1;
    private bool _isNative;
    private bool _isOpenApp;

    private void Awake()
    {
        EventHandler.AdIsShow.AddListener(() =>
        {
            _isOpenApp = true;
            SetDelay();
        });
        EventHandler.LoadEndNative.AddListener(() =>
        {
            _isNative = true;
            SetDelay();
        });
    }

    private void SetDelay()
    {
        if (_isNative && _isOpenApp)
        {
            _currentDelay = 0.05f;
        }
    }
    
    private void Start()
    {
        SetSequenceSettings();
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        int currentPercent = 0;
        _loadingText.text = currentPercent + "%";
        while (currentPercent < 100)
        {
            yield return new WaitForSeconds(_currentDelay);
            currentPercent += 1;
            _loadingText.text = currentPercent + "%";
        }
        _nextScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    #region Visual

    private void SetSequenceSettings()
    {
        _sequence = DOTween.Sequence();
        _sequence.Pause();
        FillInSequence();
        _sequence.SetLoops(-1, LoopType.Restart);
        _sequence.Play();
    }

    private void FillInSequence()
    {
        AddTweensToSequence(0, 0);
        Array.Reverse(_loadingImages);
        AddTweensToSequence(1, 1);
    }

    private void AddTweensToSequence(int origin, int fillAmountEndValue)
    {
        foreach(var image in _loadingImages)
        {
            _sequence.Append(image.DOFillAmount(fillAmountEndValue, _slideTime).OnComplete(() => image.fillOrigin = origin));
        }
    }

    #endregion
}
