using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWindow : MonoBehaviour
{
    public Transform levelPanel;
    public LevelBtn lvBtnPrefab;
    private List<LevelBtn> listLvBtn;
    public int levelUnlock;

    // Start is called before the first frame update
    void Start()
    {
        int countMap = InGameData.Instance.mapDatas.Count;
        listLvBtn = new();
        for (int i = 0; i < countMap; i++)
        {
            LevelBtn btn = Instantiate(lvBtnPrefab, levelPanel);
            btn.IntinializeButton((i + 1).ToString(), i < levelUnlock, i);
            listLvBtn.Add(btn);
        }
        gameObject.SetActive(false);
    }
}
