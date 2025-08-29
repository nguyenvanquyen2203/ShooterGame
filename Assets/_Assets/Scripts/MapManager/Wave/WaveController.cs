using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    private static WaveController instance;
    public static WaveController Instance { get { return instance; } }
    public WaveData data;
    public Slider waveProcess;
    public ParticleSystem snowEffect;
    private EnemySpawner enemySpawn;
    private List<Enemy> enemies = new();
    private List<Enemy> enemiesBurn = new();
    private List<SingleEffect> burnEffects = new();
    private bool isSnow;
    private float snowTime;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        enemySpawn = GetComponent<EnemySpawner>();
    }
    private void Start()
    {
        Invoke(nameof(SpawnWave), 2f);
    }
    void SpawnWave()
    {
        foreach (var enemy in data.listEnemyPos)
        {
            Enemy tempEnemy = PoolManager.Instance.Get<Enemy>(enemy.nameEnemy);
            tempEnemy.ActiveEnemy(enemy.position, this);
            if (isSnow) tempEnemy.Freeze();
            enemies.Add(tempEnemy);
        }
    }
    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count <= 0) SpawnWave();
    }
    public void RemoveBurnEnemy(Enemy enemy)
    {
        enemiesBurn.Remove(enemy);
        SingleEffect burn = burnEffects[0];
        burn.gameObject.SetActive(false);
        burnEffects.Remove(burn);
    }
    private void Update()
    {
        foreach (var enemy in enemies) enemy.Action();
        for (int i = 0; i < enemiesBurn.Count; i++)
        {
            burnEffects[i].transform.position = enemiesBurn[i].transform.position;
            enemiesBurn[i].Burn();
        }
        //foreach (var enemy in enemiesBurn) enemy.Burn();
        if (snowTime > 0)
        {
            snowTime -= Time.deltaTime;
            if (snowTime <= 0f)
            {
                isSnow = false;
                snowEffect.Stop();
            }
        } 
    }
    public void BurnEnemy(Enemy enemy)
    {
        enemiesBurn.Add(enemy);
        SingleEffect burn = PoolManager.Instance.Get<SingleEffect>("Burn");
        burn.gameObject.SetActive(true);
        burnEffects.Add(burn);
    }
    public void SetSnow(float snowTime)
    {
        if (!isSnow)
        {
            foreach (var enemy in enemies) enemy.Freeze();
            snowEffect.Play();
        } 
        isSnow = true;
        this.snowTime = snowTime;
    }
}
