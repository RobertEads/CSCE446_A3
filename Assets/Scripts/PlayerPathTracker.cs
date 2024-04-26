//#define debug

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathTracker : MonoBehaviour
{
    private int chaserPosition = -1;
    private int playerPosition = -2; 

    private Queue playerPath = new Queue();
    public GameObject chaser;
    

    void Start()
    {
        Invoke("spawnChaser", 5); //This will be moved to when the user presses start
    }

    // Update is called once per frame
    void Update()
    {
        if (chaserPosition == playerPosition) { Debug.Log("Player loses"); } //TODO: Lose function call happens here
        if (playerPosition == 286) { Debug.Log("Player win");  } //TODO: Win function call happens here
    }


    public void enqueue_mazeId(int id) 
    {
        playerPath.Enqueue(id);
        playerPosition = id;
    }

    public int dequeue_mazeId() { return (int) playerPath.Dequeue();}

    public bool isPathEmpty() 
    { 
        if (playerPath.Count == 0) { return true; }
        else { return false; }
    } 

    public void spawnChaser() { chaser.SetActive(true); }

    public void updateChaserPosition(int newNodeId) { chaserPosition = newNodeId; }
}
