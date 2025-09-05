using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    private static CoinManager instance;
    public static CoinManager Instance { get { return instance; } }
    public int coin;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Set this as the Singleton instance
            instance = this;
            // Optional: Make the GameObject persistent across scenes
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start()
    {
        //OptionWindowManager.Instance.SetCoinText(coin);
    }
    public int GetCoin() => coin;
    public void SpendCoin(int spendCost)
    {
        coin -= spendCost;
        OptionWindowManager.Instance.SetCoinText(coin);
    }
    public void AddCoin(int coinPlus)
    {
        coin += coinPlus;
    }
}
