// This is the Game Manager script that keeps the 
// game and collsions moving smoothly

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player;    // Gets the player object
    public Rigidbody rb;    // Get the rigibody of the player
    Vector3 spawnpoint = new Vector3(0, 1, 0);   // This holds the position of the spawnpoint
    Vector3 baseSpeed = new Vector3(0, 0, 0);    // This hold the base speed vector when not moving

    void Start()
    {
        // I'm leaving this just in-case it becomes necessary
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
