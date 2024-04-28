using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class BeaconBlinking : MonoBehaviour
{
    private bool isDecreasing = true;
    private bool isActive = false;
    private float blinkSpeed = 0.25f;

    private MeshRenderer myMeshRenderer;
    private gameManagement_Script gameManagementScript;
    private getter getValue = delegate () { return false; };
    private setter setValue = delegate (bool newValue) { };

    [SerializeField] private BEACONTYPE myType;

    void Start()
    {
        GameObject gameManagerObject = GameObject.Find("gameManager");
        gameManagementScript = gameManagerObject.GetComponent<gameManagement_Script>();

        myMeshRenderer = gameObject.GetComponent<MeshRenderer>();

        switch (myType)
        {
            case BEACONTYPE.EXIT:
                getValue = delegate () { return gameManagementScript.get_exitBeaconTokenCollected(); };
                setValue = delegate (bool newValue) { gameManagementScript.set_exitBeaconTokenCollected(newValue); };
                break;

            case BEACONTYPE.ENEMY:
                getValue = delegate () { return gameManagementScript.get_enemyBeaconTokenCollected(); };
                setValue = delegate (bool newValue) { gameManagementScript.set_enemyBeaconTokenCollected(newValue); };
                break;
        }

        resetBeacon();
    }

    void Update()
    {
        if (getValue())
        {
            setValue(false);
            myMeshRenderer.enabled = true;
            isActive = true;
            Invoke("resetBeacon", 10f);
        }

        Color textureColor = gameObject.GetComponent<Renderer>().material.color;
        if (isActive)
        {   
            if (isDecreasing)
            {
                textureColor.a = gameObject.GetComponent<Renderer>().material.color.a - (blinkSpeed * Time.deltaTime);
                if (textureColor.a <= 0.25f) { isDecreasing = false; }
            }
            else
            {
                textureColor.a = gameObject.GetComponent<Renderer>().material.color.a + (blinkSpeed * Time.deltaTime);
                if (textureColor.a >= 0.75f) { isDecreasing = true; }
            }

            gameObject.GetComponent<Renderer>().material.color = textureColor;
        }
    }

   
    public void resetBeacon()
    {
        isActive = false;
        myMeshRenderer.enabled = false;
    }

    delegate bool getter();
    delegate void setter(bool newValue);


}
