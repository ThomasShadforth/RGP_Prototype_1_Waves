using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObject : GeneralObject
{
    [SerializeField]
    GameObject relatedDoor;
    Collider2D thisCollider;
    Animator animator;

    bool openDoor;
    // Start is called before the first frame update
    void Start()
    {
        setBaseVals();
        thisCollider = relatedDoor.GetComponent<Collider2D>();
        animator = relatedDoor.GetComponent<Animator>();
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

        if (doorOpen)
        {
            StartCoroutine(openTheDoor());
            doorOpen = false;
        }

        if (playMadAnim)
        {
            
            thisAnimator.Play("DoorMad");
            thisAnimator.speed = madAnimSpeed;
        }
    }

    public IEnumerator openTheDoor()
    {
        if (!openDoor)
        {
            animator.Play("OpenDoor");
        }
        else
        {
            animator.Play("CloseDoor");
        }

        yield return new WaitForSeconds(.35f);
        enableDisableCollider();
    }

    public void enableDisableCollider()
    {
        if (!openDoor)
        {
            thisCollider.enabled = false;
        }
        else
        {
            thisCollider.enabled = true;
        }

        openDoor = !openDoor;
    }
}
