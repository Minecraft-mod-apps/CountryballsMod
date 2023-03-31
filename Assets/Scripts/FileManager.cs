using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;

public class FileManager : MonoBehaviour
{
    [SerializeField] private List<string> _modFiles;
    [SerializeField] private GameObject _installScreen;
    private string _currentModFile;
    private FileInstaller _fileInstaller;

    public IReadOnlyList<string> ModFiles => _modFiles;

    void Start()
    {
#if UNITY_EDITOR
        ConvertFilesToJSON converter = new ConvertFilesToJSON();
        converter.CreateJsonFiles(_modFiles);
#elif UNITY_ANDROID
        CheckPermission();
        _fileInstaller = new FileInstaller();
        EventHandler.StartModInstall.AddListener(InstallFile);
#endif
    }

    private void CheckPermission()
    {
        FileBrowser.RequestPermission();
    }

    private void InstallFile()
    {
        StartCoroutine(Install());
    }

    IEnumerator Install()
    {
        yield return new WaitForSeconds(0.5f);
        _installScreen.SetActive(true);
        _fileInstaller.Install(_currentModFile);
    }

    public void SetFile(int fileIndex)
    {
        _currentModFile = _modFiles[fileIndex];
    }

    public void OpenFile()
    {
        AndroidContentOpenerWrapper.OpenContent(_fileInstaller.AndroidPath + _currentModFile);
    }
}
