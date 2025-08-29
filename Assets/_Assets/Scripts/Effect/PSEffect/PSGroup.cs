using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSGroup : MonoBehaviour
{
    public List<ParticleSystem> list_PS;
    private int countPS;
    public void ActiveEffect(Vector3 activePos)
    {
        transform.position = activePos;
        gameObject.SetActive(true);
        foreach (var ps in list_PS) ps.Play();
        countPS = 0;
    }
    public void TakePS()
    {
        countPS++;
        if (countPS >= list_PS.Count) gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) ActiveEffect(Vector3.right);
    }
}
