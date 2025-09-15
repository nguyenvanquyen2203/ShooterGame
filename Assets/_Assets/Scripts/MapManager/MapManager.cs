using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private static MapManager instance;
    public static MapManager Instance { get { return instance; } }
    public WaveController waveCtrl;
    public CompositionSetUp compositionSetUp;

    private MapData mapData;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        mapData = InGameData.Instance.GetMapData();
        waveCtrl.SetWaveData(mapData.waveDatas);
        compositionSetUp.SetBG(mapData.backGround1, mapData.backGround2);
        compositionSetUp.SetFG(mapData.foreground);
    }
}

[System.Serializable] 
public class ForeGround
{
    public Sprite sprite;
    public Vector3 position;
}
