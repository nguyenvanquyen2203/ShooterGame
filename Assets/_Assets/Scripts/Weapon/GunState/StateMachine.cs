using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum TriggerEventType
    {
        Reload
    }
    protected Animator anim;
    protected string currentAnim = "GunIdle";
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeAnim(string newAnim)
    {
        if (newAnim == currentAnim) return;
        currentAnim = newAnim;
        anim.Play(currentAnim);
    }
    public void ChangeState<T>()
    {

    }
}
