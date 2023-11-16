using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSetUps : MonoBehaviour, Idoor
{
    private bool isOpen = false; 
    // Start is called before the first frame update
    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
    public void CloseDoor()
    {
        gameObject.SetActive(true);
    }
    public void ToggleDoor()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            OpenDoor();
        } else
        {
            CloseDoor(); 
        }
    }
}
