using System;
using UnityEngine;

public class JSON
{
    public static string CreateJSON<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.array = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static T[] FromJSON<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.array;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}
