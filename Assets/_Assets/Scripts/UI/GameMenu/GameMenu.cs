using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public static GameMenu Instance { get { return instance; } }
    private static GameMenu instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        AudioManager.Instance.PlayMusic("MenuMusic");
    }
    public GameObject fontPanel;
    public void OpenWindow(GameObject window)
    {
        fontPanel.gameObject.SetActive(true);
        window.transform.localScale = Vector3.zero;
        window.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutQuart).OnComplete(() => {
            fontPanel.gameObject.SetActive(false);
        });
    }
    public void CloseWindow(GameObject window)
    {
        fontPanel.gameObject.SetActive(true);
        window.transform.localScale = Vector3.one;
        window.transform.DOScale(Vector3.zero, .7f).SetEase(Ease.InBack).OnComplete(() => {
            fontPanel.gameObject.SetActive(false);
            window.SetActive(false);
        });
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
