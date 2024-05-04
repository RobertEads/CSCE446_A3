using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Windows;
using Unity.XR.CoreUtils;

public class playerMove : MonoBehaviour
{   
    private float movementSpeed = 2.5f;
    private Animator childAvatarAnimator;
    private GameObject myXrOrigin;
    private float xInput;
    private float zInput;
    private bool primaryActive = false;

    private InputData leftControllerInput;
    private PlayerPathTracker playerManagement;
    

    // Start is called before the first frame update
    void Start()
    {
        childAvatarAnimator = transform.GetChild(0).GetComponent<Animator>();

        myXrOrigin = GameObject.Find("XR Origin");
        leftControllerInput = myXrOrigin.GetComponent<InputData>();

        GameObject temp = GameObject.Find("pathTracker_player");
        playerManagement = temp.GetComponent<PlayerPathTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(myXrOrigin.transform.position, myXrOrigin.transform.rotation);
        if (leftControllerInput.leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 movement))
        {
            xInput = movement.x;
            zInput = movement.y;
            if(xInput != 0 && zInput != 0)
            {
                childAvatarAnimator.SetBool("isMoving", true);
            }
            else
            {
                childAvatarAnimator.SetBool("isMoving", false);
            }
        }

        if (leftControllerInput.leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPrimary))
        {
            if(isPrimary && !primaryActive)
            {
                Debug.Log("Changed");
                primaryActive = true;
                if(playerManagement.get_chaseDifficulty() == CHASETYPE.BASIC) { playerManagement.set_chaseDifficulty(CHASETYPE.ADVANCED); }
                else { playerManagement.set_chaseDifficulty(CHASETYPE.BASIC); }
                Invoke("clearbool", 1f);
            }
        }

        




        //General movement
        //if (Input.GetKey("a")) { GetComponent<Rigidbody>().velocity = new Vector3(movementSpeed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z); ; } //Works better for holding it down
        //if (Input.GetKey("d")) { GetComponent<Rigidbody>().velocity = new Vector3(-movementSpeed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z); childAvatarAnimator.SetBool("isMoving", true); }
        //if (Input.GetKey("s")) { GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, movementSpeed); childAvatarAnimator.SetBool("isMoving", true); }
        //if (Input.GetKey("w")) { GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, -movementSpeed); childAvatarAnimator.SetBool("isMoving", true); }
    }

    private void clearbool()
    {
        primaryActive = false;
    }
}
