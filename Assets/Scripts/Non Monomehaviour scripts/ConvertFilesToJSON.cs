using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConvertFilesToJSON
{
    private string _filePath = "Assets/ModFiles/";
    private List<byte> _bytes = new List<byte>();

    public async void CreateJsonFiles(List<string> modFiles)
    {
        foreach (var file in modFiles)
        {
            var a = File.ReadAllBytesAsync(_filePath + file);
            await a;
            _bytes.AddRange(a.Result);
            List<List<byte>> newBytes = _bytes.SliceList(Mathf.CeilToInt((float)_bytes.Count / 3));
            for(int i = 0; i < newBytes.Count; i++)
            {
                var b = File.WriteAllTextAsync(_filePath + file + $"{i+1}.json", JSON.CreateJSON<byte>(newBytes[i].ToArray()));
                await b;
            }
            _bytes.Clear();
        }
    }
}
