using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class GuiSettings : MonoBehaviour
{
    [Header("Background")]
    [SerializeField] private Image _background;
    [SerializeField] private Sprite _backgroundSprite;
    [Space]
    [Header("Loading screen settings")]
    [SerializeField] private Image _icon;
    [SerializeField] private Sprite _iconSprite;
    [Space]
    [Header("Main text background settings")]
    [SerializeField] private Image[] _mainTextBackgrounds;
    [SerializeField] private Sprite _mainTextBackgroundSprite;
    [Space]
    [Header("Description background settings")]
    [SerializeField] private Image[] _descriptionTextBackgrounds;
    [SerializeField] private Sprite _descriptionBackgroundSprite;
    [Space]
    [Header("Screenshots settings")]
    [SerializeField] private Image[] _screenshots;
    [SerializeField] private Sprite[] _screenshotsSprites;
    [Space]
    [Header("Pr.Policy and Instructions background")]
    [SerializeField] private Image[] _prPoliceAndInstructionsBack;
    [SerializeField] private Sprite _prPoliceAndInstructionsBackSprite;
    [Space]
    [Header("Push windows settings")]
    [SerializeField] private Image[] _askShowAdsWindows;
    [SerializeField] private Image _rateAppWindow;
    [SerializeField] private Color _askWindowColor;
    [SerializeField] private Color _rateWindowColor;

    private void Update()
    {
        if(Application.isEditor == true)
        {
            SetGUI();
        }
    }

    private void SetGUI()
    {
        _background.sprite = _backgroundSprite;

        _icon.sprite = _iconSprite;

        foreach (var a in _mainTextBackgrounds) a.sprite = _mainTextBackgroundSprite;

        foreach (var a in _descriptionTextBackgrounds) a.sprite = _descriptionBackgroundSprite;

        for (int i = 0; i < _screenshots.Length; i++) _screenshots[i].sprite = _screenshotsSprites[i];

        foreach (var a in _prPoliceAndInstructionsBack) a.sprite = _prPoliceAndInstructionsBackSprite;

        foreach (var a in _askShowAdsWindows) a.color = _askWindowColor;

        _rateAppWindow.color = _rateWindowColor;
    }
}
