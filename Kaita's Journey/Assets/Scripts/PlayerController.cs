using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public Vector2 velocity;
    private Rigidbody2D myRB;
    public float jumpVelocity = 5;
    public float flyingAccel = 1f;
    public float maxHoldingJtime = 10f;
    public float holdJtimer = 0.0f;
    public bool isGrounded = false;
    public bool isHoldingJ = false;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        velocity = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = myRB.velocity;

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f);

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                myRB.velocity = velocity;
                isHoldingJ = true;
                holdJtimer = 0;
            }
        }

        else if (!isGrounded && isHoldingJ)
        {
            if (isHoldingJ && holdJtimer < maxHoldingJtime)
            {
                holdJtimer += Time.deltaTime;

                velocity.y += flyingAccel;
            }


            if (holdJtimer >= maxHoldingJtime || Input.GetKeyUp(KeyCode.Space))
                isHoldingJ = false;
        }

        velocity.x = Input.GetAxisRaw("Horizontal") * speed;

        myRB.velocity = velocity;
    }
}

