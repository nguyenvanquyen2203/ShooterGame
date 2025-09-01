using UnityEngine;
using DG.Tweening;
public class StopSignDestroy : PlayerHealth
{
    public CanvasGroup sliderCanvasGroup;
    public override void Destroy()
    {
        gameObject.SetActive(false);
    }
    public override void TakeHit(float damage, bool isCritical)
    {
        base.TakeHit(damage, isCritical);
        DOTween.Kill(sliderCanvasGroup);
        sliderCanvasGroup.alpha = 1f;
        sliderCanvasGroup.gameObject.SetActive(true);
        sliderCanvasGroup.DOFade(0f, 2f).SetEase(Ease.InQuart).OnComplete(() => {
            sliderCanvasGroup.gameObject.SetActive(false);

        });
    }
}
