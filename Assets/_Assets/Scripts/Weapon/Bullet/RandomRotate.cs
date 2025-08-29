using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    private void OnEnable()
    {
        Vector3 targetEulerAngles = Vector3.zero;
        targetEulerAngles.z = Random.Range(0, 360f);
        transform.eulerAngles = targetEulerAngles;
    }
}
