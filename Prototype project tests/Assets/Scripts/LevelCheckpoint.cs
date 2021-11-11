using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCheckpoint : MonoBehaviour
{
    public bool levelEnd;
    public bool lastLevel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerTest>())
        {
            if (levelEnd)
            {
                if (!lastLevel)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    //Write code to open a UI panel perhaps, which lets the player go back to the menu
                }
            }
        }
    }
}
