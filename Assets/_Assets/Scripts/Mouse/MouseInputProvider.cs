using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MouseInputProvider : MonoBehaviour, IObserver<PauseGameAction>
{
    private static MouseInputProvider instance;
    public static MouseInputProvider Instance { get { return instance; } }
    private PlayerInput input;
    private InputAction mouse;

    public Camera _mainCamera;
    public LayerMask monsterLayer;
    public LayerMask itemLayer;
    private bool isPause;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        input = new PlayerInput();
        mouse = input.Mouse.MouseClick;
        mouse.Enable();
        mouse.performed += ctx => ClickAction();
        mouse.canceled += ctx => StopClickAction();
    }
    private void Start()
    {
        PauseGameController.Instance.AddObserver(this);
    }
    private void ClickAction()
    {
        if (isPause) return;
        // Create a ray from the camera through the mouse position
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        // GetRayIntersection correctly applies the layerMask for a point test
        RaycastHit2D itemHit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, itemLayer);
        if (itemHit.collider)
        {
            BaseItem item = itemHit.transform.gameObject.GetComponent<BaseItem>();
            item.InteractionItem();
            return;
        }
        //GunMachine.Instance.ClickAction();
        WeaponManager.Instance.ClickAction();
    }
    private void StopClickAction()
    {
        WeaponManager.Instance.StopClickAction();
    }
    private void OnDisable()
    {
        mouse.Disable();
    }

    public void OnNotify(PauseGameAction obj)
    {
        isPause = obj == PauseGameAction.Pause;
    }
}
