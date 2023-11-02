using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class ShootingController : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPoint; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(bulletPoint, shootingPoint.position, transform.rotation);
        }
    }
}
