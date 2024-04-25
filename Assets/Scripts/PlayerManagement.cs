using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    private PlayerPathTracker playerPathTracker_script;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerPathTracker_object = GameObject.Find("pathTracker_player");
        playerPathTracker_script = playerPathTracker_object.GetComponent<PlayerPathTracker>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void enqueueMazeIdToPath(int mazeUnit_id_) { Debug.Log("Reached player, calling path managaer"); playerPathTracker_script.enqueue_mazeId(mazeUnit_id_); }

}
