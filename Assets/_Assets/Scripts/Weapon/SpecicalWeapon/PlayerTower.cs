using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : PlayerHealth
{
    private static PlayerTower instance;
    public static PlayerTower Instance { get { return instance; } }
    private float healthMultiply = 1;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        OptionDefenderData healthBuff = InGameData.Instance.GetTowerBuff("Wood");
        if (healthBuff.currentLv > 0) healthMultiply = healthBuff.value;
        maxHP *= healthMultiply;
        currentHp = maxHP;
    }
    public override void Destroy()
    {
        GameManager.Instance.GameOver(false);
    }
}
