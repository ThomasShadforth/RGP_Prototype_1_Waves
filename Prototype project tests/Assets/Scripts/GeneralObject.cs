using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum objectType
{
    Door,
    Bridge,
    Stairs,
    Ladder
}

public class GeneralObject : MonoBehaviour
{
    public bool doorOpen, bridgeBuild, stairsMade, ladderFormed;
    public bool isMad, timerSet, playMadAnim;
    public Animator thisAnimator;
    public float angryTimer, madAnimSpeed;
    float angryTime;
    public string requiredWaveType;


    public NPCUI NPCSUI;
    public objectType objectVar;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //Section: Mad Timer and Cooldown
        //Triggered when the player uses the wrong wave on a person
        //They enter a temporary 'Mad' state, which prevents them from being
        //Interacted with
        if(isMad && !timerSet)
        {
            NPCSUI.setActiveStatus();
            playMadAnim = true;
            angryTime = angryTimer;
            
            timerSet = true;
        }

        /*if (isMad)
        {
            angryTime -= GamePause.deltaTime;
            if(angryTime <= 0)
            {
                
                isMad = false;
                timerSet = false;
            }
        }*/


        
    }

    public void setBaseVals()
    {
        thisAnimator = GetComponent<Animator>();
        madAnimSpeed = 1 / angryTimer;
    }

    public void deactivateMadState()
    {
        NPCSUI.setActiveStatus();
        isMad = false;
        timerSet = false;
        playMadAnim = false;
        
        thisAnimator.speed = 1;
        thisAnimator.Play("Idle");
    }
}
