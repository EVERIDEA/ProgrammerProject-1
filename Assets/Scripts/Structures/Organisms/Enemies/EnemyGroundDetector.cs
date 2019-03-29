using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundDetector : MonoBehaviour
{
    public bool canJump;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            canJump = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            canJump = false;
        }
    }
}
