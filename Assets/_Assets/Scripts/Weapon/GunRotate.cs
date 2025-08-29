using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunRotate : MonoBehaviour
{
    public Camera _mainCamera;
    private Vector2 gunDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 mousePos = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        gunDir = mousePos - (-9f * Vector2.right);
        if (gunDir.x < 0) gunDir.x = 0f;
        gunDir = gunDir.normalized;
        Vector3 targetEulerAngles = Vector3.zero;
        if (gunDir.x != 0f)
        {
            targetEulerAngles.z = Mathf.Clamp(Mathf.Atan2(gunDir.y, gunDir.x) * Mathf.Rad2Deg, -90f, 90f);
        }
        transform.eulerAngles = targetEulerAngles;
    }
    public Vector3 GetAngle() => gunDir;
}
