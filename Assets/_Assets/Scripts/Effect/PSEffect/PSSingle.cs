using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSSingle : MonoBehaviour
{
    private PSGroup group;
    private void Awake()
    {
        group = transform.parent.GetComponent<PSGroup>();
    }
    public void OnDisable()
    {
        group.TakePS();
    }
}
