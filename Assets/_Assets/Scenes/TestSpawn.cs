using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    public int numberSpawn;
    public TestMove gO;
    private List<TestMove> gOs = new();
    private void Start()
    {
        for (int i = 0; i < numberSpawn; i++)
        {
            TestMove newGO = Instantiate(gO, transform);
            newGO.Active(Vector3.one, 5f, new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0f));
            gOs.Add(newGO);
        }
    }
    public void EnableAll()
    {
        foreach (var x in gOs) x.Active(Vector3.one, 5f, new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0f));
    }
}
