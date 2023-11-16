using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    public bool doorOpen = false;
    public float doorTime = 5.0f;
    public float timer = 0f;

    public GameObject pressurePlate;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (doorOpen && (timer < doorTime))
            timer += Time.deltaTime;

        else if (doorOpen && timer >= doorTime)
        {
            doorOpen = false;
            timer = 0;
            transform.Translate((Vector2.up * -1) * transform.localScale.y);
        }

        if (pressurePlate.GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<CircleCollider2D>()) && !doorOpen)
        {
            doorOpen = true;

            transform.Translate(Vector2.up * transform.localScale.y);
        }
    }
}
