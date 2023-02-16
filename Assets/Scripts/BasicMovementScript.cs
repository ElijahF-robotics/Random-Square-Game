// This is the player movement script
// It creates an icy movement paired with sudden jumping

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementScript : MonoBehaviour
{
    // We start by defining basic variables
    private float speed = 100;
    private NewControls nc;     // This creates an instance of the input class
    public Rigidbody rb;

    public float jumpHeight = 20f;
 
    // This is an UNUSED jump coroutine, the current system works better
    IEnumerator jump()
    {
        Vector3 moveInput = nc.PlayerAction.Movement.ReadValue<Vector3>();
        if (moveInput[1] > 0)
        {
            rb.AddForce(0, jumpHeight, 0);
            yield return new WaitForSeconds(1f);
        }
        else
        {
            yield return null;
        }
        
    }
    // This function is called when the input system is awake
    void Awake()
    {
        nc = new NewControls();
    }
    // This function is called when the input system is enabled
    private void OnEnable()
    {
        nc.PlayerAction.Enable();
    }
    // This function is called when the input system is disabled
    private void OnDisable()
    {
        nc.PlayerAction.Disable();
    }
    
    void FixedUpdate()
    {
        // Gets the input Vector3 value and adds that force to the rigidbody
        // DOES NOT CHANGE THE Y
        Vector3 moveInput = nc.PlayerAction.Movement.ReadValue<Vector3>();
        moveInput[1] = 0;   // Sets y to always zero
        rb.AddForce(moveInput * speed);
    }

    void Update()
    {
        // This is where y changes
        float spacePressed = nc.PlayerAction.Jump.ReadValue<float>();   // A value that is 1 when space is pressed
        Vector3 jumping = new Vector3(0, jumpHeight, 0);    // A new vector for jumping
        // When space is pressed the player goes straight up
        // consequently, they stop moving in any other direction
        if (spacePressed == 1 && rb.position[1] == 1.5)
        {
            rb.velocity = (Vector3.up * jumpHeight);
        }
    }

}
