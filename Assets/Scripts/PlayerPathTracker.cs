using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathTracker : MonoBehaviour
{
    //Put some sort of list in here that the player will add to when it enters a new square - gonna be a queue so the chaser script can pop each one off easily
    private Queue playerPath = new Queue();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Funtions to add maze unit ids from the player and retirive the maze unit ids for tracking by the monster
    public void enqueue_mazeId(int id) { Debug.Log("Reached path manager, enqueueing"); playerPath.Enqueue(id); Debug.Log(dequeue_mazeId()); }

    public int dequeue_mazeId() { return (int) playerPath.Dequeue();}
}
