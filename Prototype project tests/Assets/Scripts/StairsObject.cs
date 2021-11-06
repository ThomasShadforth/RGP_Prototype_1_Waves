using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsObject : GeneralObject
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject relatedStairs;
    Animator animator;
    bool canWalkStairs;
    void Start()
    {
        setBaseVals();
        animator = relatedStairs.GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if(isMad && !timerSet)
        {
            playMadAnim = true;
            timerSet = true;
        }

        if (playMadAnim)
        {
            thisAnimator.Play("StairsMad");
            thisAnimator.speed = madAnimSpeed;
        }

        if (stairsMade)
        {
            StartCoroutine(buildTheStairs());
        }
    }

    public IEnumerator buildTheStairs()
    {
        if (!canWalkStairs)
        {
            animator.Play("StairsBuild");
            canWalkStairs = true;
        }
        yield return new WaitForSeconds(.6f);
        enableDisableStairs();
    }

    public void enableDisableStairs()
    {
        relatedStairs.GetComponent<Collider2D>().enabled = true;
    }
}
