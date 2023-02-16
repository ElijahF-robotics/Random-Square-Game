// This is a script to handle player collision
// with various objects

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Set up the variables for the player
    public GameObject player;
    public Rigidbody rb;
    public Vector3 spawnpoint = new Vector3(0, 1, 0);   // This holds the position of the spawnpoint
    Vector3 baseSpeed = new Vector3(0, 0, 0);

    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Enemy")
        {
            rb.velocity = baseSpeed;
            player.SetActive(false);    // Deactivates the player gameobject
            player.transform.position = spawnpoint;
            player.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Finish")
        {
            Debug.Log("YOU WIN!!!");
            player.SetActive(false);
        }
    }
    void Update()
    {
        // The following if statement checks to see if the 
        // player fell of the map, and if so it moves them 
        // back to the starting position
        if (player.transform.position[1] <= -3)
        {
            rb.velocity = baseSpeed;
            player.SetActive(false);    // Deactivates the player gameobject
            player.transform.position = spawnpoint;
            player.SetActive(true);
        }
    }

}
