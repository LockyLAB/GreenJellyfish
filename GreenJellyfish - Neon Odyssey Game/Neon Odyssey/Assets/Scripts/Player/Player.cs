using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

[RequireComponent(typeof(PlayerController))]
public class Player : Character
{

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    public float accelerationTimeAirborne = .37f;
    public float accelerationTimeGrounded = .02f;
    public float moveSpeed = 12;

    public Vector2 wallLeap;

    public float jumpDelay = 10;
    float jumpDelayTimer;

    public float wallSlideSpeedMax = 0;
    public float wallStickTime = 0.0f;
    float timeToWallUnstick;

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    PlayerController pController;

    public bool isFirstPlayer;

    public XboxController controller;

    //Setting up landing effect
    private bool m_inAir = true;
    public GameObject m_landingEffect = null;


    //public bool isDead;
    void Start()
    {
        pController = GetComponent<PlayerController>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

        SetHealth(m_healthMax);
    }

    public override void CharaterActions()
    {
        //Stop crashes due to delta time being set to 0.0f
        if (Time.timeScale == 0.0f)
            return;

        //Landing animation
        if(m_inAir)
        {
            if(pController.m_CollisionInfo.bottom) // Hit ground
            {
                Instantiate(m_landingEffect, gameObject.transform.position, Quaternion.identity);
                m_inAir = false;
            }
        }
        else
        {
            if (!pController.m_CollisionInfo.bottom) //Just jumped
            {
                m_inAir = true;
            }
        }

        Vector2 input = new Vector2(XCI.GetAxisRaw(XboxAxis.LeftStickX, controller), XCI.GetAxisRaw(XboxAxis.LeftStickY, controller));

        if (IsDead())
        {
            input = new Vector2(0, 0);
        }

        if(pController.m_CollisionInfo.bottom)
        {
            jumpDelayTimer = jumpDelay;
        }
        jumpDelayTimer -= Time.deltaTime;

        int wallDirX = (pController.m_CollisionInfo.left) ? -1 : 1;

        

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (pController.m_CollisionInfo.bottom) ? accelerationTimeGrounded : accelerationTimeAirborne);

        bool wallSliding = false;
        if ((pController.m_CollisionInfo.left || pController.m_CollisionInfo.right) && !pController.m_CollisionInfo.bottom && !IsDead())
        {
            wallSliding = true;

            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            
        }

        if (pController.m_CollisionInfo.top || pController.m_CollisionInfo.bottom)
        {
            velocity.y = 0;
        }



        if (XCI.GetButtonDown(XboxButton.A, controller) && !IsDead())
        {
            if (wallSliding)
            {
                    velocity.x = -wallDirX * wallLeap.x;
                    velocity.y = wallLeap.y;
            }
            if (pController.m_CollisionInfo.bottom || jumpDelayTimer > 0)
            {
                velocity.y = jumpVelocity;
            }
        }

        if(velocity.x > 0)
        {
            this.gameObject.transform.GetChild(0).rotation = (Quaternion.Euler(0, 90, 0));
        }
        if(velocity.x < -1)
        {
            this.gameObject.transform.GetChild(0).rotation = (Quaternion.Euler(0, 270, 0));
        }

        velocity.y += gravity * Time.deltaTime;
        pController.Move(velocity * Time.deltaTime);
    }
}
