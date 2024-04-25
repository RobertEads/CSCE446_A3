using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private float movementSpeed = 2.5f;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        print("Game Started");
    }

    // Update is called once per frame
    void Update()
    {
        //Player reset on falloff
        if (GetComponent<Transform>().position.y < -5) {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GetComponent<Transform>().position = new Vector3(0, 1, 0);
        }

        //Movemnt Speed
        if (Input.GetKey("left shift")) { movementSpeed = 4f; }
        else { movementSpeed = 2.5f; }

        //Single Jump
        if (Input.GetKeyDown("space") && isGrounded) { GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, (float)4, GetComponent<Rigidbody>().velocity.z); } //Works for a single use input

        //General movement
        if (Input.GetKey("d")) { GetComponent<Rigidbody>().velocity = new Vector3(movementSpeed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z); } //Works better for holding it down
        if (Input.GetKey("a")) { GetComponent<Rigidbody>().velocity = new Vector3(-movementSpeed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z); }
        if (Input.GetKey("w")) { GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, movementSpeed); }
        if (Input.GetKey("s")) { GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, -movementSpeed); }


        //Player follow mouse
        /*Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10));
        if(mousePosition.x > transform.position.x) {transform.position = new Vector3(transform.position.x + (float)0.01, transform.position.y, transform.position.z); }
        else if(mousePosition.x < transform.position.x) {transform.position = new Vector3(transform.position.x - (float)0.01, transform.position.y, transform.position.z); }*/


    }

    void OnTriggerStay(Collider other)
    {
        isGrounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
