using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    private Rigidbody2D myRB;

    private float horizontal; 
    public float runSpeed = 10f;
    public float jumpHeight = 16f;
    public float groundDetectDistance = 0.5f;
    private bool isFacingRight = true;
    private Vector3 moveDirection; 

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private float speed, levitationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && isGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight); 
        }
        
        Vector2 tempVel = myRB.velocity;

        tempVel.x = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump") && Physics2D.Raycast(transform.position, Vector2.down, groundDetectDistance))
            tempVel.y += jumpHeight;

        //moving our chracter 
        myRB.velocity = tempVel;
        Flip();
        Fly();
  
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runSpeed, rb.velocity.y);
    }
    private void Fly()
    {
        moveDirection = Vector3.up * levitationSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
            controller.Move(moveDirection);
        else if (Input.GetKey(KeyCode.LeftShift))
            controller.Move(-moveDirection);
    }
    private void Flip ()
    {
        if(isFacingRight && horizontal < 0f || isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale; 
        }
    }
    private bool isGround()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.3f, groundlayer);
    }
}
