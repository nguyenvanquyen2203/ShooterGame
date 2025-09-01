using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int GetCoin() => coin;
    public void SpendCoin(int spendCost)
    {
        coin -= spendCost;
    }
}
