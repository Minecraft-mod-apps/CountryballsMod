using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Collections;
using System.Threading.Tasks;

public class ButtonAnimation : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Color[] _colors;
    private TextMeshProUGUI _text;
    private int _colorIndex = 0;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        Sequence seq = DOTween.Sequence();
        seq.Append(_text.DOFade(0, _duration).OnComplete(() =>
        {
            _text.color = _colors[_colorIndex];
            _colorIndex = _colorIndex >= _colors.Length - 1 ? 0 : _colorIndex + 1;
        }
        ));
        seq.Append(_text.DOFade(1, _duration));
        seq.SetLoops(-1);
    }
}
