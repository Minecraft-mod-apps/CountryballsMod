using System;
using UnityEngine;

public class JSONHelper
{
    [Serializable]
    private class ClassArray<T>
    {
        public T[] array;
    }

    public static string ToJson<T>(T[] array)
    {
        ClassArray<T> classAray = new ClassArray<T>();
        classAray.array = array;
        return JsonUtility.ToJson(classAray);
    }

    public static T[] FromJson<T>(string json)
    {
        ClassArray<T> classArray = JsonUtility.FromJson<ClassArray<T>>(json);
        return classArray.array;
    }
}


