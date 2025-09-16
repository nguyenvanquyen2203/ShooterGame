using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float delay;
    private float cooldown;
    private float damage;
    private bool isSpiked;
    // Start is called before the first frame update
    private void Awake()
    {
    }
    void Start()
    {
        OptionDefenderData spikes = InGameData.Instance.GetTowerBuff("Spikes");
        if (spikes.currentLv <= 0) gameObject.SetActive(false);
        else damage = spikes.value;
        cooldown = delay;
        isSpiked = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (cooldown > 0) cooldown -= Time.fixedDeltaTime;
        else
        {
            cooldown = delay;
            var hits = Physics2D.BoxCastAll(transform.position, new Vector2(1f, 8f), 0f, Vector2.zero, 0f, enemyLayer);
            foreach (var hit in hits)
            {
                if (hit.collider != null)
                {
                    Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                    enemy.TakeHit(damage, false);
                    isSpiked = true;
                }
            }
            if (isSpiked)
            {
                isSpiked = false;
                AudioManager.Instance.PlaySFX("SpikeAttack");
            }
        }
    }
}
