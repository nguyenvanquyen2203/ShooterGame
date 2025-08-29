using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGO : MonoBehaviour
{
    public void DisableGO() => gameObject.SetActive(false);
    public void EnableGO() => gameObject.SetActive(true);
}
