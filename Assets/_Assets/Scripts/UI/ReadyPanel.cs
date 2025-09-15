using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ReadyPanel : MonoBehaviour
{
    private Animator anim;
    private TextMeshProUGUI text;
    public List<string> readyNumber;
    public List<string> readyWord;
    public Transform panel;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        text = GetComponent<TextMeshProUGUI>();
        //gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        ReadyAction();
    }
    public void ReadyAction()
    {
        StartCoroutine(ReadyCoroutine());
    }
    IEnumerator ReadyCoroutine()
    {
        //AudioManager.Instance.PlaySFX("Ready");
        panel.DOScaleY(1f, 1f).OnComplete(() => {
            panel.gameObject.SetActive(true);
        });
        yield return new WaitForSeconds(1f);
        int indexString = 0;
        while (indexString < readyNumber.Count)
        {
            AudioManager.Instance.PlaySFX("Ready");
            text.text = readyNumber[indexString];
            anim.Play("NumberAnim", -1,0f);
            yield return new WaitForSeconds(1f);
            indexString++;
        }
        indexString = 0;
        while (indexString < readyWord.Count)
        {
            AudioManager.Instance.PlaySFX("Ready");
            text.text = readyWord[indexString];
            anim.Play("WordAnim", -1, 0f);
            yield return new WaitForSeconds(1f);
            indexString++;
        }
        panel.DOScaleY(0f, 1f).OnComplete(() => {
            GameManager.Instance.StartGame();
            panel.gameObject.SetActive(true);
        });
        yield return null;
    }

}
