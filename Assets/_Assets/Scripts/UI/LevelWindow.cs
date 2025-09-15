using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWindow : MonoBehaviour
{
    public List<MapData> mapDatas;
    public Transform levelPanel;
    public LevelBtn lvBtnPrefab;
    private List<LevelBtn> listLvBtn;
    public int levelUnlock;

    // Start is called before the first frame update
    void Start()
    {
        listLvBtn = new();
        for (int i = 0; i < mapDatas.Count; i++)
        {
            LevelBtn btn = Instantiate(lvBtnPrefab, levelPanel);
            btn.IntinializeButton((i + 1).ToString(), i < levelUnlock, mapDatas[i]);
            listLvBtn.Add(btn);
        }
        gameObject.SetActive(false);
    }
}
