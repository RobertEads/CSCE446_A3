using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Timer monsterTimer;
    public Timer exitBeaconTimer;
    public Timer speedBoostTimer;
    public Timer enemyBeaconTimer;

    public fadeScreen faderWhite;
    public fadeScreen faderRed;

    private gameManagement_Script gameManagementScript;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        GameObject gameManagerObject = GameObject.Find("gameManager");
        gameManagementScript = gameManagerObject.GetComponent<gameManagement_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterTimer.isCompleted())
        {
            Debug.Log("Spawn the monster now.");
        }

        if (gameManagementScript.get_exitBeaconTokenCollected())
        {
            StartExitBeaconTimer(10);
        }

        if (gameManagementScript.get_speedTokenCollected())
        {
            StartSpeedBoostTimer(10);
        }

        if (gameManagementScript.get_enemyBeaconTokenCollected())
        {
            StartEnemyBeaconTimer(10);
        }
    }

    public void StartGame()
    {
        monsterTimer.StartTimer(15);
    }

    public void StartExitBeaconTimer(int duration)
    {
        exitBeaconTimer.StartTimer(duration);
    }

    public void StartSpeedBoostTimer(int duration)
    {
        speedBoostTimer.StartTimer(duration);
    }

    public void StartEnemyBeaconTimer(int duration)
    {
        enemyBeaconTimer.StartTimer(duration);
    }

    public void FadeOnWin()
    {
        faderWhite.FadeOut();
    }

    public void FadeOnLose()
    {
        faderRed.FadeOut();
    }
}
