// This is a script to handle the particle system
// when the player collides with the win
// system

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollision : MonoBehaviour
{
    public GameObject FireworksAll;
      void OnTriggerEnter (Collider coll) {
        Debug.Log("Player Won");
          if (coll.GetComponent<Collider>().CompareTag ("Player")) {
              Explode ();
          }
      }
      void Explode () {
          FireworksAll.GetComponent<ParticleSystem>().Play();
      }
}
