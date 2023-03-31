using System.Collections.Generic;
using UnityEngine;

public static class ListExtension
{
    public static List<List<T>> SliceList<T>(this List<T> list, int chunkCapacity)
    {
        List<List<T>> newList = new List<List<T>>();
        for(int i = 0; i < list.Count; i += chunkCapacity)
        {
            newList.Add(list.GetRange(i, Mathf.Min(chunkCapacity, list.Count - i)));
        }
        return newList;
    }
}
