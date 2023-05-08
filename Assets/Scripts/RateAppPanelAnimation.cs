using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RateAppPanelAnimation : MonoBehaviour
{
    [SerializeField] private Transform _rateAppWindow;
    [SerializeField] private float _duration;

    void Start()
    {
        _rateAppWindow.DOLocalMove(Vector3.zero, _duration);
        _rateAppWindow.DORotate(Vector3.zero, _duration);
    }

    public void DestroyPanel()
    {
        Destroy(gameObject);
    }
}
