using UnityEngine;
using System.Collections;

public class HelicoAmmo : Ammo
{

    public float speed;

    public override void Launch()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-1f * speed, 0);
    }

    void FixedUpdate()
    {

    }
}
