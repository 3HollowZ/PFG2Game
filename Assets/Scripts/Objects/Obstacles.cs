using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//
        {
            Activate(collision.gameObject);//
        }

    }

    public virtual void Activate(GameObject player)//
    {
        
    }


}