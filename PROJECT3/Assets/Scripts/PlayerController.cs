using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource zoom;
    public float speed;
    public float jumpForce;
    private Rigidbody2D rBody;
    public Animator animator;
    private bool isLaunchpad;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsLaunchpad;
    Vector2 dest = Vector2.zero;
    private bool hasKey;
    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        zoom = GetComponent<AudioSource>();
        facingRight = true;
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        
        

        if (horiz == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }

        HandleMovement(horiz);

        Flip(horiz);

    }

    private void HandleMovement(float horiz)
    {
        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);
    }

    private void Flip(float horiz)
    {
        if (horiz > 0 && !facingRight || horiz <0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;

            
        }
    }


    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))))
        {
            rBody.velocity = Vector2.up * jumpForce;
        }
        else if (isGrounded == false)
        {
            animator.SetBool("isJumping", true);
        }
        else if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }

        isLaunchpad = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsLaunchpad);
        if (isLaunchpad == true && (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))))
        {
            {
                zoom.Play();
                rBody.velocity = Vector2.up * 20;
            }
        }

        

    }
}
