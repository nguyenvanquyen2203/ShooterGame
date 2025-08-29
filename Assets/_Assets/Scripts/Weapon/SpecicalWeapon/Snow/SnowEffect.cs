using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowEffect : MonoBehaviour
{
    public ParticleSystem icePotionEffect;
    // Start is called before the first frame update
    public void Active(Vector3 actiovePos)
    {
        icePotionEffect.transform.position = actiovePos;
        icePotionEffect.gameObject.SetActive(true);
    }
}
