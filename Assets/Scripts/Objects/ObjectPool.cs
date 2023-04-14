using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private List<T> pool;
    private T prefab;

    public ObjectPool(T prefab, int initialSize)
    {
        this.prefab = prefab;
        pool = new List<T>(initialSize);
        for (int i = 0; i < initialSize; i++)
        {
            T obj = Object.Instantiate(prefab);
            obj.gameObject.SetActive(false);
            pool.Add(obj);
        }
    }

    public T Get()
    {
        foreach (T obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }
        T newObj = Object.Instantiate(prefab);
        pool.Add(newObj);
        return newObj;
    }

    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
    }
}
