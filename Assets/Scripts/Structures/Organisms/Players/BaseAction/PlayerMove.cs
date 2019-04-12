using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove
{
    Transform trans;

    public PlayerMove(Transform trans)
    {
        this.trans = trans;
    }

    public void Move(int direction, float speed)
    {
        trans.position = new Vector3(trans.position.x + (direction * speed * Time.deltaTime), trans.position.y, -1.7f);
        trans.localScale = new Vector2(direction, trans.localScale.y);
    }
}
