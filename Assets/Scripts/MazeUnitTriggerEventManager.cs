using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MazeUnitTriggerEventManager : MonoBehaviour
{
    //Put some sort of identifer in here that the player and chaser with retreive when they interact with the box 
    [SerializeField] private int myUnitId;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void childDetectedCollision(Collider other)
    {
        Debug.Log("Collision in parent, passing on to player"); other.gameObject.GetComponent<PlayerManagement>().enqueueMazeIdToPath(myUnitId);
    }
}
