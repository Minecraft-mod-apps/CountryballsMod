using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ButtonAnimation : MonoBehaviour
{
    private Image _buttonImage;
    void Start()
    {
        _buttonImage = GetComponent<Image>();
        _buttonImage.DOFade(0f, 1f).SetLoops(-1, LoopType.Yoyo);
        transform.DOScale(0.5f, 1f).SetLoops(-1, LoopType.Yoyo);
    }
}
