using UnityEngine;
using TMPro;
using DG.Tweening;

public class TextEffect : PoolObject
{
    private TextMeshPro txt;
    private void Awake()
    {
        //txt = GetComponent<TextMeshPro>();
    }
    public void ActiveEffect(Vector3 activePos, string text)
    {
        transform.position = activePos;
        transform.localScale = Vector3.one;
        txt.text = text;
        Color txtColor = txt.color;
        txtColor.a = 1;
        txt.color = txtColor;
        gameObject.SetActive(true);
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMoveY(activePos.y + 1f, 2f).SetEase(Ease.InOutCubic));
        mySequence.Join(txt.DOFade(0f, 2f).SetEase(Ease.InOutCubic));
        mySequence.Join(transform.DOScale(new Vector3(.75f, .75f, 1f), 2f).SetEase(Ease.InOutCubic));
        mySequence.OnComplete(() =>
        {
            OwnerPool.ReturnToPool(this);
        });
    }

    public override void OnCreate()
    {
        txt = GetComponent<TextMeshPro>();
    }
}