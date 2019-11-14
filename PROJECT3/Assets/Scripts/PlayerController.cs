using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rBody;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        
        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.W)))){
            rBody.velocity = Vector2.up * jumpForce;
        }
    }
}
