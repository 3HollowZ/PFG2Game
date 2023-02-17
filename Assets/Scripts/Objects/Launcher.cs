using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : Obstacles
{

    [SerializeField] float bounce = 10f;

    public override void Activate(GameObject player)
    {
        player.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
    }
}
