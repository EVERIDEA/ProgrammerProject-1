using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump
{
    Transform trans;
    Rigidbody2D rb;

    public PlayerJump(Transform trans)
    {
        this.trans = trans;

        rb = trans.GetComponent<Rigidbody2D>();
    }

    public void Jump (float jumpPower)
    {
        rb.velocity = Vector2.up * jumpPower;
    }
}
