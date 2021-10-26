using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeObject : GeneralObject
{
    bool bridgeBuiltDone;
    [SerializeField]
    GameObject relatedBridge;

    public Animator animator;
    Collider2D thisCollider;
    void Start()
    {
        setBaseVals();
        thisCollider = relatedBridge.GetComponent<Collider2D>();
        animator = relatedBridge.GetComponent<Animator>();
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

        if (bridgeBuild)
        {
            if (!bridgeBuiltDone)
            {
                StartCoroutine(buildTheBridge());
                animator.SetBool("isBeingBuilt", true);
                bridgeBuild = false;
            }
            else
            {
                bridgeBuild = false;
            }
        }

        if (playMadAnim)
        {
            thisAnimator.Play("BridgeMad");
            thisAnimator.speed = madAnimSpeed;
        }
    }

    public IEnumerator buildTheBridge()
    {
        animator.Play("BuildBridge");
        yield return new WaitForSeconds(0f);
        thisCollider.enabled = true;

    }
}
