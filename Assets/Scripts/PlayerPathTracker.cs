#define debug

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathTracker : MonoBehaviour
{
    private Queue playerPath = new Queue();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Funtions to add maze unit ids from the player and retirive the maze unit ids for tracking by the monster
    public void enqueue_mazeId(int id) 
    {
        #if debug
            Debug.Log("Reached path manager, enqueueing id: " + id.ToString()); 
        #endif
        playerPath.Enqueue(id); 
    }

    public int dequeue_mazeId() { return (int) playerPath.Dequeue();}
}
