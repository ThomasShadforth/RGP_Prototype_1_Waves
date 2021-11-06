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

    
}
