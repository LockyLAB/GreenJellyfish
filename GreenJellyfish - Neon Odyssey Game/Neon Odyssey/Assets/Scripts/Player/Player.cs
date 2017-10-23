﻿using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .37f;
    float accelerationTimeGrounded = .02f;
    public float moveSpeed = 12;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public float wallSlideSpeedMax = 0;
    public float wallStickTime = 0.0f;
    float timeToWallUnstick;

    float faceDirX;

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    PlayerController pController;

    public bool isFirstPlayer;

    public XboxController controller;

    public bool isDead;
    void Start()
    {
        pController = GetComponent<PlayerController>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
    }

    void Update()
    {
        
        if (Time.timeScale == 0.0f)
            return;

        Vector2 input = new Vector2(XCI.GetAxisRaw(XboxAxis.LeftStickX, controller), XCI.GetAxisRaw(XboxAxis.LeftStickY, controller));
        if (isDead)
        {
            input = new Vector2(0, 0);
        }

        if(XCI.GetAxisRaw(XboxAxis.LeftStickX, controller) < 0)
        {
            faceDirX = -1;
        }
        else
        {
            faceDirX = 1;
        }

        int wallDirX = (pController.m_CollisionInfo.left) ? -1 : 1;

        

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (pController.m_CollisionInfo.bottom) ? accelerationTimeGrounded : accelerationTimeAirborne);

        bool wallSliding = false;
        if ((pController.m_CollisionInfo.left || pController.m_CollisionInfo.right) && !pController.m_CollisionInfo.bottom && !isDead)
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



        if (XCI.GetButtonDown(XboxButton.A, controller) && !isDead)
        {
            if (wallSliding)
            {
                    velocity.x = -wallDirX * wallLeap.x;
                    velocity.y = wallLeap.y;
            }
            if (pController.m_CollisionInfo.bottom)
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
