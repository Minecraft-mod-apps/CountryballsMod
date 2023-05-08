using TMPro;
using UnityEngine;

public class InstallScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _installScreens;
    [SerializeField] private TMP_Text _screenText;
    
    public void SetScreen(int i)
    {
        foreach(var screen in _installScreens) screen.SetActive(false);
        _installScreens[i].SetActive(true);
    }
    
    public void SetScreenName(string name)
    {
        _screenText.text = name;
    }
 }
