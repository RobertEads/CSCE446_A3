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

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterTimer.isCompleted())
        {
            Debug.Log("Spawn the monster now."); //TO-DO: Call for spawn enemy/monster
        }
    }

    public void StartGame()
    {
        monsterTimer.StartTimer(30);
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
