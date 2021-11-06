using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLadderClimb : MonoBehaviour
{
    PlayerTest attachedPlayer;
    bool canClimbLadder;
    GameObject ladder;

    public float climbSpeed;
    void Start()
    {
        attachedPlayer = GetComponent<PlayerTest>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canClimbLadder && !attachedPlayer.isClimbingLadder && Input.GetButtonDown("Up"))
        {
            attachedPlayer.isClimbingLadder = true;
        }

        if (attachedPlayer.isClimbingLadder)
        {
            if (Input.GetButton("Up"))
            {
                //Move Up Ladder
                transform.position = new Vector3(ladder.transform.position.x, transform.position.y + climbSpeed * GamePause.deltaTime, transform.position.z);
            } else if (Input.GetButton("Down"))
            {
                transform.position = new Vector3(ladder.transform.position.x, transform.position.y - climbSpeed * GamePause.deltaTime, transform.position.z);
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            ladder = other.gameObject;
            canClimbLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            canClimbLadder = false;
            attachedPlayer.isClimbingLadder = false;
            ladder = null;
        }
    }
}
