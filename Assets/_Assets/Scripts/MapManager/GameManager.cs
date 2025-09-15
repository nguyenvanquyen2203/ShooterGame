using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour, IObserver<PauseGameAction>
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
    private float cooldownPigeon;
    private bool isStart;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        PauseGameController.Instance.AddObserver(this);
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
        AudioManager.Instance.PlayMusic("GameMusic");
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
    private void PauseGame()
    {
        Time.timeScale = 0f;
    }
    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void OnNotify(PauseGameAction obj)
    {
        if (obj == PauseGameAction.Pause) PauseGame();
        else ResumeGame();
    }
}
