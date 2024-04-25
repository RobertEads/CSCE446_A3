//#define debug

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    private PlayerPathTracker playerPathTracker_script;

    void Start()
    {
        GameObject playerPathTracker_object = GameObject.Find("pathTracker_player");
        playerPathTracker_script = playerPathTracker_object.GetComponent<PlayerPathTracker>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void enqueueMazeIdToPath(int mazeUnit_id_) 
    {
        #if debug
            Debug.Log("Reached player, calling path managaer"); 
        #endif
        playerPathTracker_script.enqueue_mazeId(mazeUnit_id_); 
    }

}
