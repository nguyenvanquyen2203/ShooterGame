using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private static MovementManager instance;
    public static MovementManager Instance { get { return instance; } }
    private List<MovementObserver> observers = new();
    private void Awake()
    {
        instance = this;
    }
    public void Register(MovementObserver observer) => observers.Add(observer);
    public void Unregister(MovementObserver observer) => observers.Remove(observer);
    private void Update()
    {
        for (int i = 0; i < observers.Count; i++)
        { 
            if (!observers[i].Move())
            {
                observers[i].DoneMove();
                observers.RemoveAt(i);
                i--;
            }
        }
    }
}
