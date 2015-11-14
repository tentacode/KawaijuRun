using UnityEngine;
using System.Collections;
using System;

public class TankAmmo : Ammo
{
    public float speed;

    public override void Launch()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-1f * speed, 0);
    }
}
