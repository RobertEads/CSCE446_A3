using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMove : MonoBehaviour
{   
    private float movementSpeed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        //General movement
        if (Input.GetKey("a")) { GetComponent<Rigidbody>().velocity = new Vector3(movementSpeed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z); } //Works better for holding it down
        if (Input.GetKey("d")) { GetComponent<Rigidbody>().velocity = new Vector3(-movementSpeed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z); }
        if (Input.GetKey("s")) { GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, movementSpeed); }
        if (Input.GetKey("w")) { GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, -movementSpeed); }
    }
}
