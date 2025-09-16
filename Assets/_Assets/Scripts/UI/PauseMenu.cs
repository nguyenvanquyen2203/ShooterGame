using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PauseMenu : MonoBehaviour, IObserver<PauseGameAction>
{
    public CanvasGroup bg;
    public Transform menu;
    public GameObject fontPanel;
    private void Start()
    {
        PauseGameController.Instance.AddObserver(this);
        gameObject.SetActive(false);
    }
    private void ShowMenu()
    {
        gameObject.SetActive(true);
        fontPanel.SetActive(true);
        bg.alpha = 0;
        bg.DOFade(1, 1f);
        menu.localScale = Vector3.zero;
        menu.DOScale(Vector3.one, 1f).SetEase(Ease.OutBack).SetUpdate(UpdateType.Normal, true).OnComplete(() => {
            fontPanel.SetActive(false);
        });
    }
    private void HideMenu()
    {
        fontPanel.SetActive(true);
        bg.alpha = 1;
        bg.DOFade(0, .5f);
        menu.localScale = Vector3.one;
        menu.DOScale(Vector3.zero, .5f).SetEase(Ease.OutSine).SetUpdate(UpdateType.Normal, true).OnComplete(() => {
            fontPanel.SetActive(false);
            gameObject.SetActive(false);
        });
    }

    public void OnNotify(PauseGameAction obj)
    {
        if (obj == PauseGameAction.Pause) ShowMenu();
        else HideMenu();
    }
}
