// This is the enemy movement script that creates enemy's that
// travel in a square
// May be replaced by something better

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Get the starting x, y, and z
    public float x = 7f;
    public float y = 1.5f;
    public float z = 3f;
    
    // Get the gameobject
    public GameObject ene;

    // Set up the waypoints 
    public Transform[] waypoints;

    // Set up navmesh agent, and target managment
    public UnityEngine.AI.NavMeshAgent enemy;
    public int currentTarget = 0;
    public bool targetReached = false;

    // Update is called once per frame
    void Update()
    {
        // If waypoints has things and currentTarget has a number
        if (waypoints.Length > 0 && waypoints[currentTarget] != null)
        {
            // Gets the distance between goal and current position
            float distance = Vector3.Distance(transform.position, waypoints[currentTarget].position);
            // If your close and haven't checked yet
            if (distance < 1f && targetReached == false)
            {
                targetReached = true;
                if (currentTarget == (waypoints.Length - 1))
                { 
                    StartCoroutine(WaitBeforeMoving());
                    currentTarget = 0;
                }
                else
                {
                    StartCoroutine(WaitBeforeMoving());
                    currentTarget ++;
                }
            }
            // Else keep going
            else if (distance > 1f && targetReached == false)
            {
                enemy.destination = waypoints[currentTarget].position;
            }
        }
    }

    // The coroutine to handle the enemy stopping at each waypoint
    IEnumerator WaitBeforeMoving()
    {
        yield return new WaitForSeconds(0.1f);
        targetReached = false;
    }
}
