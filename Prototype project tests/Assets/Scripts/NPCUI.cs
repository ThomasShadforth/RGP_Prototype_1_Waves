using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCUI : MonoBehaviour
{
    [SerializeField]
    GeneralObject attachedNPC;
    
    public GameObject UI;

    public Sprite[] waveIcons;
    public Image waveImage;

    string[] waveTypes;
    void Start()
    {
        attachedNPC = GetComponentInParent<GeneralObject>();

        setWaveIcon();

    }

    // Update is called once per frame
    void Update()
    {
        if (!attachedNPC.deactivateUI)
        {
            UI.SetActive(true);
        }
        else
        {
            UI.SetActive(false);
        }
    }

    

    public void setActiveStatus()
    {
        attachedNPC.deactivateUI = false;
    }

    public void setWaveIcon()
    {
        for(int i = 0; i < waveIcons.Length; i++)
        {
            if(waveIcons[i].name == attachedNPC.requiredWaveType)
            {
                waveImage.sprite = waveIcons[i];
            }
        }
    }
}
