using System;
using System.Collections;
using System.Collections.Generic;
using Native;
using UnityEngine;

public class NativeRegister : MonoBehaviour
{
    [SerializeField] private QueueNative _native;

    private void OnEnable()
    {
        StartCoroutine(ShowAd());
    }

    private IEnumerator ShowAd()
    {
        yield return new WaitForSeconds(0.5f);
        _native.RegisterAd();
        yield break;
    }
}
