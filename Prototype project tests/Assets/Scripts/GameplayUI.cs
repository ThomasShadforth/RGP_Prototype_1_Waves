using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    public static GameplayUI instance;

    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text timeText;
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
        scoreText.text = "Score: " + GameManager.instance.pointNum;

        //timeText.text = "Time: " + GameManager.instance.levelTime;
    }
}
