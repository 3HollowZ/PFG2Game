using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//
        {
            LaunchActivate(collision.gameObject);//
        }
    }

    public virtual void LaunchActivate(GameObject player)//
    {
        
    }
}