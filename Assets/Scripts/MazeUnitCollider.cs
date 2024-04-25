using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeUnitCollider : MonoBehaviour
{
    private MazeUnitTriggerEventManager parentScript;
    // Start is called before the first frame update
    void Start()
    {
        parentScript = gameObject.GetComponentInParent<MazeUnitTriggerEventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Detected");
        if (other.gameObject.tag == "Player") { Debug.Log("Collision w/ player, passing to parent"); parentScript.childDetectedCollision(other); }
    }
}
