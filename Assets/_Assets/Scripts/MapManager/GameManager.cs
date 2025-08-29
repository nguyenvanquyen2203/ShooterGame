using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public Transform coinIcon;  
    public PSGroup boxBreakEffect;
    public CarrierPigeon pigeon;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    public void ActiveBoxEffect(Vector3 activePos)
    {
        boxBreakEffect.ActiveEffect(activePos);
    }
    public Vector3 GetCoinIconPos()
    {
        return Camera.main.ScreenToWorldPoint(coinIcon.transform.position);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) pigeon.Transport(Vector3.zero);
    }
}
