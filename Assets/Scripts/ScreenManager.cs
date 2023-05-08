using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class ScreenManager : MonoBehaviour
{
    [Header("Start loading settings")]
    [SerializeField] private TextMeshProUGUI _loadingCount;
    [SerializeField] private float _loadingDelay;
    [SerializeField] private int _loadingDivision;
    private float _currentDelay = 1;
    [Header("Screens settings")]
    [SerializeField] private List<GameObject> _allScreens;
    [Header("Load mod screen settings")]
    [SerializeField] private GameObject _loadModScreen;
    [SerializeField] private TextMeshProUGUI _loadModMainText;

    private int _indexCurrentScreen = 0;

    private bool _isNative;
    private bool _isAppOpen;

    void Start()
    {
        EventHandler.EnableNextScreen.AddListener(EnableNextScreen);
        EventHandler.EnablePrevScreen.AddListener(EnablePreviousScreen);
        EventHandler.StartLoadFile.AddListener(ActivateLoadModScreen);
        EventHandler.CloseLoadScreen.AddListener(CloseLoadScreen);
        EventHandler.SetLoadScreenName.AddListener(SetLoadScreenName);
        EventHandler.LoadingIsEnd.AddListener(() =>
        {
            _isAppOpen = true;
            SetDelay();
        });
        EventHandler.LoadEndNative.AddListener(() =>
        {
            _isNative = true;
            SetDelay();
        });
        
        EventHandler.ReturnToStart.AddListener(() =>
        {
            foreach (var VARIABLE in _allScreens)
            {
                VARIABLE.SetActive(false);
            }

            _indexCurrentScreen = 1;
            _allScreens[_indexCurrentScreen].SetActive(true);
        });

        StartCoroutine(Loading());
    }

    private void SetDelay()
    {
        if (_isNative && _isAppOpen)
        {
            _currentDelay = _loadingDelay;
        }
    }

    IEnumerator Loading()
    {
        int loadCount = 0;
        while(loadCount < 100)
        {
            loadCount += _loadingDivision;
            _loadingCount.text = loadCount + "%";
            yield return new WaitForSeconds(_currentDelay);
        }
        EventHandler.LoadingIsEnd.Invoke();
        EnableNextScreen();
    }

    private void EnableNextScreen()
    {
        _allScreens[_indexCurrentScreen].SetActive(false);
        _indexCurrentScreen++;
        _allScreens[_indexCurrentScreen].SetActive(true);
    }

    private void EnablePreviousScreen()
    {
        _allScreens[_indexCurrentScreen].SetActive(false);
        _indexCurrentScreen--;
        _allScreens[_indexCurrentScreen].SetActive(true);
    }

    private void SetLoadScreenName(string newName)
    {
        _loadModMainText.text = newName;
    }

    private void ActivateLoadModScreen()
    {
        _allScreens[_indexCurrentScreen].SetActive(false);
        _loadModScreen.SetActive(true);
    }

    private void CloseLoadScreen()
    {
        _allScreens[_indexCurrentScreen].SetActive(true);
        _loadModScreen.SetActive(false);
    }
}
