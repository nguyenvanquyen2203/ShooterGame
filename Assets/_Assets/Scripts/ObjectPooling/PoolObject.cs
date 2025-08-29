using UnityEngine;

public abstract class PoolObject : MonoBehaviour, IPoolable
{
    // A reference to the pool controller that this object belongs to.
    public IObjectPool OwnerPool { get; set; }
    protected string nameObject;

    // Implementation of the interface methods.
    public virtual void OnGetFromPool()
    {
        gameObject.SetActive(true);
    }

    public virtual void OnReturnToPool()
    {
        gameObject.SetActive(false);   
    }
    public void SetNameObject(string newName) => nameObject = newName;
    public abstract void OnCreate();
}