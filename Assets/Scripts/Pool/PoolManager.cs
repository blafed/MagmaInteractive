using UnityEngine;
using System.Collections.Generic;
public class PoolManager : Singleton<PoolManager>
{
    List<PoolHandler> poolHandlers = new List<PoolHandler>();

    public PoolInstance Use(GameObject prefab)
    {
        PoolHandler poolHandler = poolHandlers.Find(x => x.prefab == prefab);
        if (poolHandler == null)
        {
            poolHandler = new PoolHandler(prefab);
            poolHandlers.Add(poolHandler);
        }
        return poolHandler.GetInstance();
    }
    public void Remove(PoolInstance instance)
    {
        PoolHandler poolHandler = poolHandlers.Find(x => x.prefab == instance.gameObject);
        if (poolHandler != null)
        {
            poolHandler.ReturnInstance(instance);
        }
    }
}