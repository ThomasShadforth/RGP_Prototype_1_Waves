using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int pointNum;
    public float levelTimer;
    public float levelTime;

    public Vector2 checkPointPos;
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levelTime > 0)
        {
            levelTime -= 1 * GamePause.deltaTime;
        }

        if(levelTime <= 0)
        {
            //Reset Level?
            //Or start reducing score
        }
    }

    public void increasePoints(int pointVal)
    {
        pointNum += pointVal;
        //Update on UI
    }

    public void movePosition()
    {
        PlayerTest[] playersInLevel = FindObjectsOfType<PlayerTest>();

        for(int i = 0; i < playersInLevel.Length; i++)
        {
            if (playersInLevel[i].isControlled)
            {
                playersInLevel[i].transform.position = checkPointPos;
                break;
            }
        }
    }
    
}
