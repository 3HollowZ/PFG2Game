using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public enum EnemyType
    {
        Normal
    }

    public class Enemies
    {
        public string name;
        public float speed;

        public Enemies(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Normal:
                    name = "Normal Enemy";
                    speed = 5.0f;
                    break;
            }
        }
    }
}