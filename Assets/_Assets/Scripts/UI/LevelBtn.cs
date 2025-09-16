using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelBtn : MonoBehaviour
{
    public TextMeshProUGUI txt;
    private Button button;
    private int indexMap;
    public void IntinializeButton(string content, bool isActive, int _indexMap)
    {
        button = GetComponent<Button>();
        button.interactable = isActive;
        txt.text = content;
        indexMap = _indexMap;
    }
    public void SaveMapData()
    {
        InGameData.Instance.SetMapData(indexMap);
    }
    public void LoadScene()
    {
        SaveMapData();
        AudioManager.Instance.StopMusic();
        GameMenu.Instance.LoadGameScene();
    }
}
