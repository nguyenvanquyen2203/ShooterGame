using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OverPanel : MonoBehaviour
{
    public Button nextLvBtn;
    public TextMeshProUGUI coinTxt;
    public GameObject completeGO;
    public GameObject failGO;
    public void ActiveOverPanel(string coin, bool isWin)
    {
        gameObject.SetActive(true);
        nextLvBtn.interactable = isWin;
        coinTxt.text = coin;
        completeGO.SetActive(isWin);
        failGO.SetActive(!isWin);
    }
}
