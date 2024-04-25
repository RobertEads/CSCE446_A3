//#define debug

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;


public class MazeUnitTriggerEventManager : MonoBehaviour
{
    private int myNodeId;

    void Start()
    {
        string[] parts = gameObject.name.Split('_');
        myNodeId = int.Parse(parts.Last());
    }

    private void OnCollisionEnter(Collision collision)
    {
        #if debug
            Debug.Log("Collision Detected");  
        #endif
       
        if (collision.gameObject.tag == "Player") 
        {
            #if debug
                Debug.Log("Collided with player, calling player to enqueueing my id");  
            #endif
            collision.gameObject.GetComponent<PlayerManagement>().enqueueMazeIdToPath(myNodeId); 
        }
        
    }
}
