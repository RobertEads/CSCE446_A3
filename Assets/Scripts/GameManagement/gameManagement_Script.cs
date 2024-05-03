using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BEACONTYPE
{
    ENEMY,
    EXIT
}

public enum POWERUPTYPE
{
    SPEED,
    ENEMY,
    EXIT
}

public enum CHASETYPE
{
    BASIC,
    ADVANCED
}

public class gameManagement_Script : MonoBehaviour
{
    private bool exitBeaconTokenCollected = false;
    private bool enemyBeaconTokenCollected = false;
    private bool speedTokenCollected = false;


    public bool get_exitBeaconTokenCollected() { return exitBeaconTokenCollected; }
    public bool get_enemyBeaconTokenCollected() { return enemyBeaconTokenCollected; }
    public bool get_speedTokenCollected() { return enemyBeaconTokenCollected; } //Needs to be called by the player movement stuff to increase speed and w/ invoke to decrease

    public void set_exitBeaconTokenCollected(bool newState) {  exitBeaconTokenCollected = newState; }
    public void set_enemyBeaconTokenCollected(bool newState) { enemyBeaconTokenCollected = newState; }
    public void set_speedTokenCollected(bool newState) { enemyBeaconTokenCollected = newState; }
}
