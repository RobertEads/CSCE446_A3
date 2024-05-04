using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMove : MonoBehaviour
{   
    private float movementSpeed = 2.5f;
    private Animator childAvatarAnimator;
    private GameObject origin;

    // Start is called before the first frame update
    void Start()
    {
        childAvatarAnimator = transform.GetChild(1).GetComponent<Animator>();
        //childAvatarAnimator = GetComponent<Animator>();
        origin = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        childAvatarAnimator.SetBool("isMoving", false);
        transform.SetPositionAndRotation(origin.transform.position, origin.transform.rotation);
        childAvatarAnimator.SetBool("isMoving", true);
        //General movement
        //if (Input.GetKey("a")) { GetComponent<Rigidbody>().velocity = new Vector3(movementSpeed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z); ; } //Works better for holding it down
        //if (Input.GetKey("d")) { GetComponent<Rigidbody>().velocity = new Vector3(-movementSpeed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z); childAvatarAnimator.SetBool("isMoving", true); }
        //if (Input.GetKey("s")) { GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, movementSpeed); childAvatarAnimator.SetBool("isMoving", true); }
        //if (Input.GetKey("w")) { GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, -movementSpeed); childAvatarAnimator.SetBool("isMoving", true); }
    }
}
