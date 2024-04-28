using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PowerUps : MonoBehaviour
{
    private MeshRenderer myRenderer;
    private MeshCollider myCollider;
    private gameManagement_Script gameManagementScript;

    [SerializeField] private POWERUPTYPE myPowerupType;

    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myCollider = GetComponent<MeshCollider>();

        GameObject gameManagerObject = GameObject.Find("gameManager");
        gameManagementScript = gameManagerObject.GetComponent<gameManagement_Script>();
    }

    // Update is called once per frame
    void Update()
    {
       //Maybe some kind of bounce here?
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            myRenderer.enabled = false;
            myCollider.enabled = false;

            switch (myPowerupType)
            {
                case POWERUPTYPE.SPEED:
                    gameManagementScript.set_speedTokenCollected(true);
                    break;
                case POWERUPTYPE.ENEMY:
                    gameManagementScript.set_enemyBeaconTokenCollected(true);
                    break;
                case POWERUPTYPE.EXIT:
                    gameManagementScript.set_exitBeaconTokenCollected(true);
                    break;
            }
        }
    }
}
