using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;


    private Rigidbody2D rb;
    Vector2 moveVelocity;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime, transform.position.y);
        //moveVelocity = moveInput.normalized * Speed;
        rb.MovePosition(rb.position + moveInput );
    }
    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
