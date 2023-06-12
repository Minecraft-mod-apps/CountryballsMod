using System;
using System.Collections;
using UnityEngine;

public class CrashlyticsTester : MonoBehaviour 
{
    private void Start ()
    {
        StartCoroutine(throwExceptionEvery60Updates());
    }
    
    private IEnumerator throwExceptionEvery60Updates()
    {
        yield return new WaitForSeconds(5f);
        throw new Exception("test exception please ignore");
    }
}