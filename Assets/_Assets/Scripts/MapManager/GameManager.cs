using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public Transform coinIcon;  
    public PSGroup boxBreakEffect;
    public CarrierPigeon pigeon;
    private int currentCoin;
    public TextMeshProUGUI coinTxt;
    public GameObject readyPanel;
    public OverPanel overPanel;
    public float cooldownPigeon;
    private bool isStart;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        readyPanel.SetActive(true);
        isStart = false;
        Time.timeScale = 1f;
    }
    public void ActiveBoxEffect(Vector3 activePos)
    {
        boxBreakEffect.ActiveEffect(activePos);
    }
    public Vector3 GetCoinIconPos()
    {
        return Camera.main.ScreenToWorldPoint(coinIcon.transform.position);
    }
    public Vector3 GetSpWeaponIconPos(string spWeaponName)
    {
        return Camera.main.ScreenToWorldPoint(coinIcon.transform.position);
    }
    private void FixedUpdate()
    {
        if (isStart)
        {
            if (cooldownPigeon > 0) cooldownPigeon -= Time.fixedDeltaTime;
            else
            {
                cooldownPigeon = 10f;
                pigeon.Transport(new Vector3(Random.Range(-2f, 7f), Random.Range(-.5f, .5f), 0f));
            }
        }
        //if (Input.GetKeyDown(KeyCode.G)) pigeon.Transport(new Vector3(Random.Range(-2f, 2f), Random.Range(-.5f, .5f), 0f));
    }
    public void GetCoin(int plusCoin)
    {
        currentCoin += plusCoin;
        coinTxt.text = currentCoin.ToString();
    }
    public void StartGame()
    {
        WaveController.Instance.SpawnWave(0);
        cooldownPigeon = 10f;
        isStart = true;
    }
    public void GameOver(bool isWin)
    {
        Time.timeScale = 0f;
        isStart = false;
        CoinManager.Instance.AddCoin(currentCoin);
        WeaponManager.Instance.SaveGunBullet();
        overPanel.ActiveOverPanel(currentCoin.ToString(), isWin);
    }
}
