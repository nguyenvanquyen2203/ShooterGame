
// IObjectPool is a non-generic interface for a pool.
// This allows us to store different generic pools in a single dictionary.
public interface IObjectPool
{
    // A non-generic method to return an object to the pool.
    // It takes an IPoolable object.
    void ReturnToPool(IPoolable obj);

    // Can add other non-generic methods here if needed.
}