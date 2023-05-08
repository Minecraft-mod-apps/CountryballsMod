using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadModScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _loadText;
    [SerializeField] private GameObject _loadingbar;
    [SerializeField] private float _loadingDelay;
    [SerializeField] private Button[] _allButtons;
    private int _loadingProgress;
    private float _currentDelay;

    private void Start()
    {
        EventHandler.EndLoadFile.AddListener(() => _currentDelay = 0.02f);
    }

    private void OnEnable()
    {
        _loadingbar.SetActive(true);
        _currentDelay = _loadingDelay;
        foreach (var button in _allButtons) button.interactable = false;
        _loadingProgress = 0;
        _loadText.text = _loadingProgress + "%";
        StartCoroutine(LoadMod());
    }

    private IEnumerator LoadMod()
    {
        while(_loadingProgress < 100)
        {
            yield return new WaitForSeconds(_currentDelay);
            _loadingProgress++;
            _loadText.text = _loadingProgress + "%";
        }
        _loadingbar.SetActive(false);
        _loadText.text = "Loading is complete!";
        foreach (var button in _allButtons) button.interactable = true; 
    }
}
