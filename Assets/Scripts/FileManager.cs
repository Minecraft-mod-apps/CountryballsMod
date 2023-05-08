using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.AddressableAssets;
using SimpleFileBrowser;

public class FileManager : MonoBehaviour
{
    [SerializeField] private string _editorPath;
    [SerializeField] private string _androidPath;
    [SerializeField] private string[] _filesNames;
    private List<byte> _bytes = new List<byte>();
    private int _fileNameIndex;

    private void Start()
    {
        EventHandler.SetIndexEvent.AddListener((index) => _fileNameIndex = index);
        EventHandler.StartLoadFile.AddListener(InstallMod);
        EventHandler.OpenFileEvent.AddListener(OpenFile);
#if UNITY_EDITOR
        CreateJsonFiles();
#elif UNITY_ANDROID
        FileBrowser.RequestPermission();
#endif
    }

    private void CreateJsonFiles()
    {
        foreach(var fileName in _filesNames)
        {
            _bytes.AddRange(File.ReadAllBytes(_editorPath + fileName));
            List<List<byte>> bytesChunks = _bytes.Chunk(Mathf.CeilToInt(((float)_bytes.Count / 3)));
            foreach(var chunk in bytesChunks)
            {
                File.WriteAllText(_editorPath + fileName + bytesChunks.IndexOf(chunk) +".json", JSONHelper.ToJson(chunk.ToArray()));
            }
            _bytes.Clear();
        }
    }

    private async void InstallMod()
    {
        for(int i = 0; i < 3; i++)
        {
            var loadTask = Addressables.LoadAssetAsync<TextAsset>(_editorPath + _filesNames[_fileNameIndex] + i + ".json");
            await loadTask.Task;
            if(loadTask.IsDone)
            {
                var text = loadTask.Result;
                _bytes.AddRange(JSONHelper.FromJson<byte>(text.text));
            }
        }
        var writeTask = File.WriteAllBytesAsync(_androidPath + _filesNames[_fileNameIndex], _bytes.ToArray());
        await writeTask;
        _bytes.Clear();
        EventHandler.EndLoadFile.Invoke();
    }

    private void OpenFile()
    {
        AndroidContentOpenerWrapper.OpenContent(_androidPath + _filesNames[_fileNameIndex]);
    }
}



public static class Extension
{
    public static List<List<T>> Chunk<T>(this List<T> list, int chunkSize)
    {
        List<List<T>> newList = new List<List<T>>();
        int iteration = 0;
        for(int i = 0; i < list.Count; i += chunkSize)
        {
            if(iteration == 2)
            {
                newList.Add(list.GetRange(i, list.Count - i));
                break;
            }
            newList.Add(list.GetRange(i, Mathf.Min(chunkSize, list.Count - i)));
            iteration++;
        }
        return newList;
    }
}
