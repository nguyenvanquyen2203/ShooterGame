using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSEffect : MonoBehaviour
{
    private SingleEffect effect;
    private void Awake()
    {
        effect = GetComponent<SingleEffect>();
    }
    private void OnDisable()
    {
        effect.OwnerPool.ReturnToPool(effect);
    }
}
