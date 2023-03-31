using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class FileInstaller
{
    private string _filePath = "/storage/emulated/0/Download/";
    private string _adressablesPath = "Assets/ModFiles/";
    private List<byte> _bytes = new List<byte>();

    public string AndroidPath => _filePath;

    public async void Install(string fileName)
    {
        await ConvertAddressablesToList(fileName);

        var writeBytesAsync = File.WriteAllBytesAsync(_filePath + fileName, _bytes.ToArray());
        await writeBytesAsync;
        if (writeBytesAsync.IsCompleted)
        {
            _bytes.Clear();
            EventHandler.ModInstallComplete.Invoke();
        }
    }

    private async System.Threading.Tasks.Task ConvertAddressablesToList(string fileName)
    {
        for (int i = 1; i <= 3; i++)
        {
            var getJsonAsync = Addressables.LoadAssetAsync<TextAsset>(_adressablesPath + fileName + i + ".json");
            await getJsonAsync.Task;
            if (getJsonAsync.IsDone)
            {
                _bytes.AddRange(JSON.FromJSON<byte>(getJsonAsync.Result.text));
            }
        }
    }
}
