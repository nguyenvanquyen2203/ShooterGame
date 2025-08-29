using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBulletlPoolManager : MonoBehaviour
{
    private static GunBulletlPoolManager instance;
    public static GunBulletlPoolManager Instance { get { return instance; } }
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        //IntinializePool();
    }
    public void ActiveBullet(string name, Vector3 activePos, Vector3 targetPos)
    {

    }
}
