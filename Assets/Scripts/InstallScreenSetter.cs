using TMPro;
using UnityEngine;

public class InstallScreenSetter : MonoBehaviour
{
    [SerializeField] private GameObject[] _screens;
    [SerializeField] private TMP_Text _mainText;

    public void SetName(string name)
    {
        _mainText.text = name;
    }

    public void SetScreen(int i)
    {
        foreach (var VARIABLE in _screens)
        {
            VARIABLE.SetActive(false);
        }

        _screens[i].SetActive(true);
    }
}
