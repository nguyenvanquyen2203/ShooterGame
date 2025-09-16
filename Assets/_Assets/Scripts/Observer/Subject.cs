using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject<T> : MonoBehaviour
{
    //protected Dictionary<T, List<IObserver<T>>> _observers = new();
    protected List<IObserver<T>> _observers = new();
    public void AddObserver(IObserver<T> observer)
    {
        _observers.Add(observer);
    } 
    public void RemoveObserver(IObserver<T> observer)
    {
        _observers.Remove(observer);
    }
    public void NotifyObserver(T key)
    {
        foreach (var observer in _observers)
        {
            observer.OnNotify(key);
        }
    }
}
