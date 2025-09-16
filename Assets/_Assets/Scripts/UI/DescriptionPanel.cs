using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DescriptionPanel : MonoBehaviour
{
    public GameObject fontPanel;
    public Image img;
    public TextMeshProUGUI namePanel;
    public TextMeshProUGUI descriptionTxt;
    public void ActiveDescription(Sprite img, string namePanel, string descriptionTxt)
    {
        this.img.sprite = img;
        this.namePanel.text = namePanel;
        this.descriptionTxt.text = descriptionTxt;
        gameObject.SetActive(true);
        GameMenu.Instance.OpenWindow(gameObject);
        //fontPanel.SetActive(true);
    }
}
