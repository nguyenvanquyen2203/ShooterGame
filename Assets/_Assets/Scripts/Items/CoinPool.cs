using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : PoolObject
{
    private CoinItem coinItem;
    private Vector3 originalPosition;
    private float gravity = -9.8f * 2;
    private float startV;
    private float currentV;
    private float xMove;
    private bool isCollect;
    public void ActiveCoin(Vector3 activePos)
    {
        float h = 3f;
        isCollect = false;
        startV = Mathf.Sqrt(-2f * h * gravity);
        currentV = startV;
        xMove = Random.Range(-1f, 1f);
        transform.position = activePos;
        originalPosition = activePos;
        gameObject.SetActive(true);
    }
    private void Update()
    {
        if (isCollect) return;
        if (startV < .5f)
        {
            coinItem.CollectMove();
            isCollect = true;
            return;
        }
        currentV += gravity * Time.deltaTime;
        transform.position += (Vector3.up * currentV + Vector3.right * xMove) * Time.deltaTime;
        if (transform.position.y <= originalPosition.y)
        {
            startV /= 2;
            currentV = startV;
            transform.position = new Vector3(transform.position.x, originalPosition.y, transform.position.z);
        }
    }

    public override void OnCreate()
    {
        coinItem = GetComponent<CoinItem>();
    }
}
