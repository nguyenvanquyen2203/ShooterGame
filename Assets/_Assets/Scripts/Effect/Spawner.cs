using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Effect")]
    public PoolObj<TextEffect> textEffect;
    public PoolObj<SingleEffect> coinCollectEffect;
    public PoolObj<CoinPool> coinItem;

    [Header("Special Weapon")]
    public PoolObj<SpecialWeapon> boom;
    public PoolObj<SpecialWeapon> firePostion;
    public PoolObj<SpecialWeapon> icePostion;
    public PoolObj<SpecialWeapon> stopSign;

    [Header("Special effect")]
    public PoolObj<SingleEffect> burnEffect;
    public PoolObj<SpExplosion> boomExplosion;
    public PoolObj<SpExplosion> firePostionExplosion;
    public PoolObj<SpExplosion> snowExplosion;
    // Start is called before the first frame update
    void Start()
    {
        PoolManager.Instance.CreatePool(textEffect);
        PoolManager.Instance.CreatePool(coinCollectEffect);
        PoolManager.Instance.CreatePool(coinItem);
        PoolManager.Instance.CreatePool(burnEffect);
        PoolManager.Instance.CreatePool(stopSign);
        PoolManager.Instance.CreatePool(boom);
        PoolManager.Instance.CreatePool(boomExplosion);
        PoolManager.Instance.CreatePool(firePostion);
        PoolManager.Instance.CreatePool(icePostion);
        PoolManager.Instance.CreatePool(firePostionExplosion);
        PoolManager.Instance.CreatePool(snowExplosion);

    }
}