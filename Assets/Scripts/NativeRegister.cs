using System;
using System.Collections;
using System.Collections.Generic;
using Native;
using UnityEngine;

public class NativeRegister : MonoBehaviour
{
    [SerializeField] private QueueNative _native;
    [SerializeField] private int i;

    private void OnEnable()
    {
        _native.RegisterAd(i);
        StartCoroutine(ShowAd());
    }

    private IEnumerator ShowAd()
    {
        yield return new WaitForSeconds(0.5f);
        yield break;
    }
}
