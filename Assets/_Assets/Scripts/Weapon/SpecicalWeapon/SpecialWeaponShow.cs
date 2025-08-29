using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpecialWeaponShow : MonoBehaviour
{
    private SpriteRenderer icon;
    // Start is called before the first frame update
    private void Awake()
    {
        icon = GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
    }
    public void ActiveSpecialWeapon(Sprite _icon)
    {
        icon.sprite = _icon;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = mousePos + Vector3.forward * 10f;
    }
}
