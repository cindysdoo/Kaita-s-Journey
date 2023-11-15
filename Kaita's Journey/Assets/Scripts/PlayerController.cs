using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity;
    public float jumpVelocity;
    public float GroundHeight = 10;
    public float maxHoldingJtime = 0.4f;
    public float holdJtimer = 0.0f;
    public bool isGounded = false;
    public bool isHoldingJ = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGounded)
        {
            if (isHoldingJ)
            {
                holdJtimer += Time.fixedDeltaTime;
                if (holdJtimer >= maxHoldingJtime)
                {
                    isHoldingJ = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGounded = false;
                velocity.y = jumpVelocity;
                isHoldingJ = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJ = false;
        }
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        if (!isGounded)
        {
            pos.y += velocity.y * Time.fixedDeltaTime;
            if (isHoldingJ)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }
            velocity.y += gravity * Time.fixedDeltaTime;
            if (pos.y <= GroundHeight)
            {
                pos.y = GroundHeight;
                isGounded = true;
                holdJtimer = 0;
            }
        }

        transform.position = pos;
    }
}

