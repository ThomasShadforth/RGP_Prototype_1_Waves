using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCUI : MonoBehaviour
{
    [SerializeField]
    GeneralObject attachedNPC;
    public bool isActive;
    public GameObject UI;

    string[] waveTypes;
    void Start()
    {
        attachedNPC = GetComponentInParent<GeneralObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
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
        Debug.Log("SETTING STATUS");
    }
}
