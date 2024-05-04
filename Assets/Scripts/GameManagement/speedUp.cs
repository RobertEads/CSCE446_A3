using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class speedUp : MonoBehaviour
{

    private gameManagement_Script gameManagementScript;
    private ContinuousMoveProviderBase temp;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObject = GameObject.Find("gameManager");
        gameManagementScript = gameManagerObject.GetComponent<gameManagement_Script>();

        temp = transform.GetComponent<ContinuousMoveProviderBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagementScript.get_speedTokenCollected())
        {
            gameManagementScript.set_speedTokenCollected(false);
            temp.moveSpeed = temp.moveSpeed * 2;
            Invoke("resetSpeed", 10f);
        }
    }

    private void resetSpeed()
    {
        temp.moveSpeed = temp.moveSpeed / 2;
    }
}
