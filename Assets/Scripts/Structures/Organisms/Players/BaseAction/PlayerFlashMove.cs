using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashMove
{
    GameObject obj;
    Rigidbody2D rb;

    public PlayerFlashMove(GameObject obj)
    {
        this.obj = obj;

        rb = this.obj.GetComponent<Rigidbody2D>();
    }

    public void FlashMove(int direction, float speed)
    {
        if (direction == 1) rb.velocity = Vector2.right * 15;
        else if (direction == -1) rb.velocity = Vector2.left * 15;
    }
}
