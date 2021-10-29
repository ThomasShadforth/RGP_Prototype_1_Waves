using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public WaveButton[] waveButtons;
    public Sprite[] waveIcons;
    [SerializeField]
    PlayerTest parentPlayer;
    void Start()
    {
        parentPlayer = GetComponentInParent<PlayerTest>();

        setUIImages();
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
        parentPlayer.setWaveDistance(waveName);
    }

    void setUIImages()
    {
        for(int i = 0; i < waveButtons.Length; i++)
        {
            for(int j = 0; j < waveIcons.Length; j++)
            {
                if(waveIcons[j].name == waveButtons[i].waveName)
                {
                    waveButtons[i].GetComponent<Image>().sprite = waveIcons[j];
                }
            }
        }
    }
}
