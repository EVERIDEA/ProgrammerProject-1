using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStomp
{
    GameObject obj;
    Rigidbody2D rb;

    public PlayerStomp(GameObject obj)
    {
        this.obj = obj;

        rb = this.obj.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    public void Stomp()
    {
        //playerAnim.PlayStomp();
        rb.velocity = Vector2.down * 30;
    }
}
