using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractPressurePlaye : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    private Idoor door;
    private float timer;

    private void Awake()
    {
        door = doorGameObject.GetComponent<Idoor>();
    }
    // Update is called once per frame
    private void Update()
    {
        if ( timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                door.CloseDoor(); 
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<CharacterController>() != null)
        {
            door.OpenDoor();
            timer = 1f; 
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.GetComponent<CharacterController>() != null)
        {
            timer = 1f;
        }
    }
}
