using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderObject : GeneralObject
{
    public bool canClimb;
    [SerializeField]
    GameObject relatedLadder;
    Animator animator;
    void Start()
    {
        animator = relatedLadder.GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (isMad && !timerSet)
        {

            playMadAnim = true;
            //angryTime = angryTimer;
            timerSet = true;
        }

        if (ladderFormed)
        {
            StartCoroutine(formTheLadder());
        }
    }

    public IEnumerator formTheLadder()
    {
        if (!canClimb)
        {
            animator.Play("BuildLadder");
        }
        yield return null;
    }

    void enableDisableLadder()
    {
        //Have this enable/disable the collider
    }
}
