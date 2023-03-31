using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System.Collections;

public class InstallScreenLoading : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _mainText;
    [Header("Loading image settings")]
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _image;
    private int _spriteIndex = 0;
    [Header("Loading count settings")]
    [SerializeField] private TextMeshProUGUI _loadingCount;
    [SerializeField] private float _longLoadingDelay;
    [SerializeField] private float _shortLoadingDelay;
    private float _currentDelay;
    [Header("Buttons")]
    [SerializeField] private Button[] _buttons;

    private GameObject _prevScreen;
    private Sequence _sequence;

    private void Start()
    {
        EventHandler.ModInstallComplete.AddListener(() =>
        {
            _currentDelay = _shortLoadingDelay;
        });
        EventHandler.GetPrevScreen.AddListener((screen) =>
        {
            Debug.Log(screen.name);
            _prevScreen = screen;
        });

    }

    private void OnEnable()
    {
        _image.gameObject.SetActive(true);
        SetInteractableButtons(false);
        StartImageAnimation();
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        int currentPercent = 0;
        _currentDelay = _longLoadingDelay;
        while(currentPercent < 100)
        {
            _loadingCount.text = currentPercent + "%";
            yield return new WaitForSeconds(_currentDelay);
            currentPercent++;
        }
        EndLoading();
    }

    private void StartImageAnimation()
    {
        _sequence = DOTween.Sequence();
        _sequence.Append(_image.transform.DOScaleX(0, .2f).OnComplete(() => SetSprite()));
        _sequence.Append(_image.transform.DOScaleX(1, .2f));
        _sequence.SetLoops(-1);
    }

    private void SetSprite()
    {
        _image.sprite = _sprites[_spriteIndex];
        _spriteIndex = _spriteIndex + 1 >= _sprites.Length ? 0 : _spriteIndex + 1;
    }

    private void EndLoading()
    {
        SetInteractableButtons(true);
        _loadingCount.text = "Loading complete!";
        _image.gameObject.SetActive(false);
        _sequence.Pause();
        _sequence.Kill();
    }

    public void SetInteractableButtons(bool canInteract)
    {
        foreach (var button in _buttons)
        {
            button.interactable = canInteract;
        }
    }

    public void Backward()
    {
        _prevScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SetPrevScreen(GameObject screen)
    {
        _prevScreen = screen;
    }

    public void SetName(string name)
    {
        _mainText.text = name;
    }
}
