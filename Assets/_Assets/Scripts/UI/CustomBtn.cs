using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomBtn : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI buttonContentText;
    private Image img;
    private void Awake()
    {
        img = GetComponent<Image>();
    }
    public void SetButton(string content, string price, bool isActive)
    {
        buttonContentText.text = content;
        buttonText.text = price;
        if (isActive) ActiveButton();
        else DisactiveButton();
    }
    /*public void SetMaxButton(string content)
    {
        buttonContentText.text = content;
        buttonText.text = "";
        DisactiveButton();
    }*/
    private void ActiveButton()
    {
        button.interactable = true;
    }
    private void DisactiveButton()
    {
        button.interactable = false;
    }
}
