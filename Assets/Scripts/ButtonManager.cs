using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private string _googlePlayLink;
    [SerializeField] private string _appLink;
    [SerializeField] private FileManager _fileManager;
    [SerializeField] private GameObject[] _allScreens;
    private int _currentScreenIndex = 0;

    public void SetFileIndex(int index) => _fileManager.SetFile(index);
    public void ShowInter() => EventHandler.ShowInter.Invoke();
    public void ShowRewarded() => EventHandler.ShowRewarded.Invoke();
    public void NextScreen()
    {
        _allScreens[_currentScreenIndex].SetActive(false);
        _currentScreenIndex++;
        _allScreens[_currentScreenIndex].SetActive(true);
    }

    public void PreviousScreen()
    {
        _allScreens[_currentScreenIndex].SetActive(false);
        _currentScreenIndex--;
        _allScreens[_currentScreenIndex].SetActive(true);
    }

    public void ActivateInstallScreen(GameObject currentScreen) => EventHandler.GetPrevScreen.Invoke(currentScreen);

    public void ReturnToStart()
    {
        _allScreens[_currentScreenIndex].SetActive(false);
        _currentScreenIndex = 0;
        _allScreens[_currentScreenIndex].SetActive(true);
    }
    public void OpenFile() => _fileManager.OpenFile();
    public void RateApp() => Application.OpenURL(_appLink);
    public void MoreApps() => Application.OpenURL(_googlePlayLink);
}
