using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierPigeon : MonoBehaviour
{
    public SpriteRenderer box;
    public BoxItem boxItem;
    private Vector3 target;
    public float speed;
    private bool shipping;
    // Update is called once per frame
    void Update()
    {
        transform.position += (target - transform.position).normalized * speed * Time.deltaTime;
        if ((transform.position - target).sqrMagnitude <= .01f)
        {
            if (shipping) DeliveryCompletion();
            else gameObject.SetActive(false);
        }
    }
    public void Transport(Vector3 targetPos)
    {
        target = targetPos;
        box.gameObject.SetActive(true);
        transform.position = new Vector3(12f, 7f, 0f);
        gameObject.SetActive(true);
        shipping = true;
    }
    public void DeliveryCompletion()
    {
        shipping = false;
        box.gameObject.SetActive(false);
        boxItem.Active(box.transform.position);
        target = new Vector3(-12f, 7f, 0f);
    }
}
