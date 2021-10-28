using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public WaveButton[] waveButtons;
    [SerializeField]
    PlayerTest parentPlayer;
    void Start()
    {
        parentPlayer = GetComponentInParent<PlayerTest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Method for switching selected wave

    public void selectWave(string waveName)
    {
        
        for(int i = 0; i < waveButtons.Length; i++)
        {
            if(waveButtons[i].waveName == waveName)
            {
                waveButtons[i].selected = true;
            }
            else
            {
                waveButtons[i].selected = false;
            }

            
        }

        parentPlayer.currentWaveName = waveName;
    }
}
