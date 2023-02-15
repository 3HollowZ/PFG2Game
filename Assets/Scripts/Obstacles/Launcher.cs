using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : Obstacles
{

    [SerializeField] float bounce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void LaunchActivate(GameObject player)
    {
        player.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
    }
}
