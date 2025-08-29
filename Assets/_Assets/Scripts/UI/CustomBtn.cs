using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomBtn : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI buttonText;
    private Image img;
    private void Awake()
    {
        img = GetComponent<Image>();
    }
    public void SetButton(string content, bool isActive)
    {
        buttonText.text = content;
        if (isActive) ActiveButton();
        else DisactiveButton();
    }
    private void ActiveButton()
    {
        button.interactable = true;
        img.color = new Color(1f, 1f, 1f);
    }
    private void DisactiveButton()
    {
        button.interactable = false;
        img.color = new Color(.5f, .5f, .5f);
    }
}
