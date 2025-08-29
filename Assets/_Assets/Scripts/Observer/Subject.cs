using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    protected List<IObserver> _observers = new();
    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    } 
    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }
    public void NotifyObserver()
    {
        foreach (var observer in _observers)
        {
            observer.OnNotify();
        }
    }
}
