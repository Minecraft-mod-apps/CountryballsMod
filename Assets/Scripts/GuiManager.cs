using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[ExecuteInEditMode]
public class GuiManager : MonoBehaviour
{
    [Header("Main visual settings")]
    [SerializeField] private Image _iconImage;
    [SerializeField] private Sprite _iconSprite;
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Sprite _backgroundSprite;
    [Header("First screen settings")]
    [SerializeField] private TextMeshProUGUI _firstScreenDescription;
    [SerializeField] private string _modName;
    [Header("Main text settings")]
    [SerializeField] private Image[] _allBackgroundMainTextImages;
    [SerializeField] private Sprite _mainTextBackgroundSprite;
    [Header("Description text settings")]
    [SerializeField] private Image[] _allBackgroundDescriptionTextImages;
    [SerializeField] private Sprite _descriptionTextBackgroundSprite;
    [Header("Buttons settings")]
    [SerializeField] private Image[] _allButtonsImages;
    [SerializeField] private Sprite _buttonSprite;
    [Header("Special background")]
    [SerializeField] private Image[] _allSpecBackImages;
    [SerializeField] private Sprite _specBackSprite;
    [Header("Screenshots")]
    [SerializeField] private Image _screenshotImage1;
    [SerializeField] private Image _screenshotImage2;
    [SerializeField] private Sprite _screenshotSprite1;
    [SerializeField] private Sprite _screenshotSprite2;

    private void OnValidate()
    {
        _iconImage.sprite = _iconSprite;
        _backgroundImage.sprite = _backgroundSprite;
        foreach(var i in _allBackgroundMainTextImages)
        {
            i.sprite = _mainTextBackgroundSprite;
        }
        foreach(var i in _allBackgroundDescriptionTextImages)
        {
            i.sprite = _descriptionTextBackgroundSprite;
        }
        foreach(var i in _allSpecBackImages)
        {
            i.sprite = _specBackSprite;
        }

        foreach (var button in _allButtonsImages)
        {
            button.sprite = _buttonSprite;
        }
        _screenshotImage1.sprite = _screenshotSprite1;
        _screenshotImage2.sprite = _screenshotSprite2;
        _firstScreenDescription.text = $"We are happy  that you�ve chosen our app {_modName} that can help to download mods for " +
                                       $"the MCPE game! Be careful and don�t delete the app or there will be problems with mods. " +
                                       $"Press the START button and read the instructions without hurry!";
    }
}
