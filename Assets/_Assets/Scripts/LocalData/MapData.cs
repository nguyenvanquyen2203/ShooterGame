using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "MapData", fileName = "MapData")]
public class MapData : ScriptableObject
{
    public List<WaveData> waveDatas;
    public Sprite backGround1;
    public Sprite backGround2;
    public List<ForeGround> foreground;
    [Header("Warning")]
    public List<WarningContent> warnings;
}
[System.Serializable] 
public class WarningContent
{
    public Sprite sprite;
    public string content;
    private bool isShow = false;
    public void Show() => isShow = true;
    public bool IsShow { get { return isShow; } }
}
