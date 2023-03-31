using System.Collections;
using Native;
using UnityEngine;

public class ShowNative : MonoBehaviour
{
    [SerializeField] private QueueNative _native;

    private void OnEnable()
    {
        StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        yield return new WaitForSeconds(.5f);
        //_native.RegisterAd();
        yield break;
    }
}