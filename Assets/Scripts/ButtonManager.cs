using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private string _rateAppLink;
    [SerializeField] private string _moreAppsLink;
    [Header("Buttons visual settings")]
    [SerializeField] private Image[] _topButtons;
    [SerializeField] private Sprite _topButtonsImage;
    [SerializeField] private Image[] _middleButtons;
    [SerializeField] private Sprite _middleButtonsImage;
    [SerializeField] private Image[] _bottomButtons;
    [SerializeField] private Sprite _bottomButtonsImage;

    private void OnValidate()
    {
        foreach (var b in _topButtons)
        {
            b.sprite = _topButtonsImage;
        }
        foreach (var b in _middleButtons)
        {
            b.sprite = _middleButtonsImage;
        }
        foreach (var b in _bottomButtons)
        {
            b.sprite = _bottomButtonsImage;
        }
    }

    public void OpenURL(bool isRateApp)
    {
        if (isRateApp) Application.OpenURL(_rateAppLink);
        else Application.OpenURL(_moreAppsLink);
    }

    public void ReturnToStart() => EventHandler.ReturnToStart.Invoke();
    public void SetModIndex(int index) => EventHandler.SetIndexEvent.Invoke(index);
    public void SetLoadScreenName(string name) => EventHandler.SetLoadScreenName.Invoke(name);
    public void InstallMod() => EventHandler.StartLoadFile.Invoke();
    public void NextScreen() => EventHandler.EnableNextScreen.Invoke();
    public void PrevScreen() => EventHandler.EnablePrevScreen.Invoke();
    public void ReturnFromLoadModScreen() => EventHandler.CloseLoadScreen.Invoke();
    public void OpenMod() => EventHandler.OpenFileEvent.Invoke();
    public void ShowRewardedAd() => EventHandler.ShowRewardedAd.Invoke();
    public void ShowInterAd() => EventHandler.ShowInterAd.Invoke();
}
