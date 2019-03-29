using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InlineFrames : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public Vector3 offset;
    public float followSpeed;

    GameObject player;
    int direction;
    // Use this for initialization
    void Start()
    {
        player = target.gameObject;
        direction = player.GetComponent<PlayerControll>().playerDirection;
    }

    // Update is called once per frame
    void Update()
    {
        if (target2.position.x > 3 && target2.position.x < 45)
        {
            if (direction > 0) this.transform.position = new Vector2(-player.transform.position.x * followSpeed, this.transform.position.y);
            else if (direction < 0) this.transform.position = new Vector2(player.transform.position.x * followSpeed, this.transform.position.y);
        }
    }
}
