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
        setBaseVals();
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

        if (playMadAnim)
        {
            thisAnimator.Play("LadderMad");
            thisAnimator.speed = madAnimSpeed;
        }

    }

    public IEnumerator formTheLadder()
    {
        if (!canClimb)
        {
            animator.Play("LadderBuild");
            canClimb = true;
        }
        yield return new WaitForSeconds(.6f);
        enableDisableLadder();
    }

    void enableDisableLadder()
    {
        relatedLadder.GetComponent<Collider2D>().enabled = true;
        
    }
}
