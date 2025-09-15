using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelBtn : MonoBehaviour
{
    public TextMeshProUGUI txt;
    private Button button;
    private MapData data;
    public void IntinializeButton(string content, bool isActive, MapData _data)
    {
        button = GetComponent<Button>();
        button.interactable = isActive;
        txt.text = content;
        data = _data;
    }
    public void SaveMapData()
    {
        InGameData.Instance.SetMapData(data);
    }
    public void LoadScene()
    {
        SaveMapData();
        GameMenu.Instance.LoadGameScene();
    }
}
