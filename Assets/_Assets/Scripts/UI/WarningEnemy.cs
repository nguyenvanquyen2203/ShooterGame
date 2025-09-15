using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WarningEnemy : MonoBehaviour
{
    public TextMeshProUGUI content;
    public Image img;
    public void Intinialize(string text, Sprite sprite)
    {
        content.text = text;
        img.sprite = sprite;
    }

}
