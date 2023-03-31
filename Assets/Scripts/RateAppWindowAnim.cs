using UnityEngine;
using DG.Tweening;

public class RateAppWindowAnim : MonoBehaviour
{
    [SerializeField] private GameObject _window;
    void Start()
    {
        _window.transform.DOLocalMove(Vector3.zero, 1);
    }
}
