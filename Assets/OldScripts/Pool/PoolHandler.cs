using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolHandler
{
    public GameObject prefab;
    public Queue<PoolInstance> pool = new Queue<PoolInstance>();

    PoolHandler() { }

    public PoolHandler(GameObject prefab)
    {
        this.prefab = prefab;
    }

    public void ReturnInstance(PoolInstance instance)
    {
        instance.gameObject.SetActive(false);
        pool.Enqueue(instance);
    }

    public PoolInstance GetInstance()
    {
        PoolInstance instance = null;
        if (pool.Count > 0)
        {
            instance = pool.Dequeue();
        }
        else
        {
            instance = CreateInstance();
        }
        instance.gameObject.SetActive(true);
        return instance;
    }
    PoolInstance CreateInstance()
    {
        GameObject instance = GameObject.Instantiate(prefab);
        instance.SetActive(false);
        return instance.AddComponent<PoolInstance>();
    }

}