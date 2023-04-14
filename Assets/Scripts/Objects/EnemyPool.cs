using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public Enemy prefab;
    public int initialSize = 10;
    private ObjectPool<Enemy> pool;

    private void Start()
    {
        pool = new ObjectPool<Enemy>(prefab, initialSize);
    }

    public Enemy Get()
    {
        return pool.Get();
    }

    public void ReturnToPool(Enemy obj)
    {
        pool.ReturnToPool(obj);
    }
}
