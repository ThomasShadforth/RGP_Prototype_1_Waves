using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerTest : MonoBehaviour
{
    bool isFacingRight;
    Vector2 moveInput;

    [Header("Movement")]
    public float speed;
    const float maxSpeed = 3.0f;
    const float timeToReachMaxSpeed = .3f;
    const float timeToDecel = .3f;
    const float accelRate = (maxSpeed) / timeToReachMaxSpeed;
    const float decelRate = -(maxSpeed - (maxSpeed / 2)) / timeToDecel;
    const float friction = 2.2f;

    Rigidbody2D rb;
    Animator animator;

    int jumpCount;
    [Header("Jump Properties")]
    public int extraJumps;
    public float jumpForce;
    public LayerMask whatIsGround;
    public bool isGrounded;
    public bool isJumping;
    [SerializeField]
    Transform feetPos;
    public float detectRadius;
    public float jumpTimeCounter;
    float jumpTime;

    [Header("Wave Mechanic Properties")]
    public string currentWaveName;
    public float waveDistance;
    public bool isControlled;
    [SerializeField]
    Transform wavePos;
    public LayerMask interactables, playerLayer;

    CinemachineVirtualCamera cm;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        cm = FindObjectOfType<CinemachineTag>().GetComponent<CinemachineVirtualCamera>();

        isFacingRight = true;
        moveInput.x = 1;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, detectRadius, whatIsGround);
    }
    void Update()
    {
        if (!isControlled)
        {
            return;
        }

        if (isControlled)
        {
            cm.LookAt = transform;
            cm.Follow = transform;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            waveAction();
        }
        //Horizontal Movement
        if (Input.GetButton("Left"))
        {
            //If the player is facing right, invert move input x, set the boolean to false and change
            //The x scale
            if (isFacingRight)
            {
                moveInput.x = -1;
                isFacingRight = false;
                changeXScale(moveInput.x);
            }

            
            //while the speed is greater than 0, decelerate
            if(speed > 0)
            {
                
                speed += decelRate * 1.9f * GamePause.deltaTime;
                //When the speed falls under 0, set it to -.5
                if(speed < 0)
                {
                    speed = -.5f;
                }
            //Accelerate to the left, slowly picking up speed while the speed has yet to reach the max
            } else if(speed > -maxSpeed)
            {
                speed -= accelRate * GamePause.deltaTime;

                //Once the speed has reached beyond the max, keep setting it to the negative max (For Left)
                if(speed <= -maxSpeed)
                {
                    speed = -maxSpeed;
                }
            }
        }

        //
        else if (Input.GetButton("Right"))
        {
            
            if (!isFacingRight)
            {
                moveInput.x = 1;
                isFacingRight = true;
                changeXScale(moveInput.x);
            }

            
            if(speed < 0)
            {
                speed -= decelRate * 1.9f * GamePause.deltaTime;
                if(speed > 0)
                {
                    speed = .5f;
                }
            } else if(speed < maxSpeed)
            {
                speed += accelRate * GamePause.deltaTime;

                if(speed >= maxSpeed)
                {
                    speed = maxSpeed;
                }
            }
        }

        if(!Input.GetButton("Left") && !Input.GetButton("Right"))
        {
            speed -= (Mathf.Min(Mathf.Abs(speed * 2.2f), friction * 2.2f) * Mathf.Sign(speed) * maxSpeed * Time.deltaTime);
        }

        //Vertical Movement
        if (Input.GetButtonDown("Jump") && isGrounded && jumpCount == 0){
            rb.velocity = Vector2.up * jumpForce;
            jumpTime = jumpTimeCounter;
            isJumping = true;
        }

        if(Input.GetButtonDown("Jump")  && jumpCount > 0)
        {
            jumpCount--;
            rb.velocity = Vector2.up * jumpForce;
            jumpTime = jumpTimeCounter;
            isJumping = true;
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if(jumpTime > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTime -= GamePause.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        if (isGrounded)
        {
            jumpCount = extraJumps;
        }

        //Checks for Wave Action Input
        
    }

    public void swapWave(string waveName, float range)
    {
        currentWaveName = waveName;
        waveDistance = range;
    }

    public void switchPlayerObject(PlayerTest otherPlayer)
    {
        speed = 0;
        isControlled = false;
        otherPlayer.isControlled = true;
        otherPlayer = null;
        //Insert code for changing the camera's focus
    }

    public IEnumerator switchPlayer(PlayerTest otherPlayer)
    {
        speed = 0;
        isControlled = false;
        yield return new WaitForSeconds(.3f);
        otherPlayer.isControlled = true;
        
    }

    public void waveAction()
    {
        //Make sure to set this up once animator and animations are in place for the player
        animator.Play(currentWaveName);

        Debug.DrawRay(wavePos.position, moveInput.x > 0 ? Vector2.right : -Vector2.right, Color.green, 1f);

        RaycastHit2D hit = Physics2D.Raycast(wavePos.position, moveInput.x > 0 ? Vector2.right : -Vector2.right, waveDistance, interactables);

        if (hit)
        {
            GeneralObject foundObject = hit.collider.GetComponent<GeneralObject>();

            if (foundObject.isMad)
            {
                
            }
            else
            {
                if (foundObject.requiredWaveType == currentWaveName)
                {
                    checkObjectType(foundObject);
                }
                else
                {
                    
                    foundObject.isMad = true;
                }
            }
            

        }
        else
        {
            RaycastHit2D playerObj = Physics2D.Raycast(wavePos.position, moveInput.x > 0 ? Vector2.right : -Vector2.right, waveDistance, playerLayer);
            if (playerObj)
            {


                PlayerTest playerToSwap = playerObj.collider.GetComponent<PlayerTest>();
                StartCoroutine(switchPlayer(playerToSwap));

            }
        }

        

    }

    public void LateUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void changeXScale(float moveInputx)
    {
        Vector3 scalar = transform.localScale;
        scalar.x = -scalar.x;
        transform.localScale = scalar;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(wavePos.position, new Vector3(wavePos.position.x + waveDistance, wavePos.position.y, wavePos.position.z));
        Gizmos.DrawWireSphere(feetPos.position, detectRadius);
    }

    public void checkObjectType(GeneralObject foundObject)
    {
        if(foundObject.objectVar == objectType.Bridge)
        {
            foundObject.bridgeBuild = true;
        } else if(foundObject.objectVar == objectType.Door)
        {
            foundObject.doorOpen = true;
        } else if(foundObject.objectVar == objectType.Ladder)
        {

        } else if(foundObject.objectVar == objectType.Stairs)
        {

        }
    }
}
