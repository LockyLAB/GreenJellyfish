using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

[RequireComponent(typeof(PlayerController))]
public class Player : Character
{

    public float jumpHeight = 4; // vertical height the player jumps
    public float timeToJumpApex = .4f; // Time it takes to reach max jump height
    public float accelerationTimeAirborne = .37f; // acceleration in air
    public float accelerationTimeGrounded = .02f; // acceleration on the ground
    public float moveSpeed = 12; // Player move speed 

    public Vector2 wallLeap; // Vector2 to control leaping off walls

    public float jumpDelay = 10; // Delay for jumping after walking of a ledge
    float jumpDelayTimer; // timer for jump delay

    public float wallSlideSpeedMax = 0; // Max wall slide speed
    public float wallStickTime = 0.0f; 
    float timeToWallUnstick; // Float controlling time to unsticking to wall

    float gravity; // float that controls gravity
    float jumpVelocity; // speed for jump
    public Vector3 velocity; // Velcoity on player
    float velocityXSmoothing; 

    PlayerController pController; // reference to player controller script

    public bool isFirstPlayer; // Checks for first player

    public XboxController controller; // Defines which xbox controller controls this script
    public XboxButton jumpButton = XboxButton.A;

    void Start()
    {
        pController = GetComponent<PlayerController>(); // reference to player controller script

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2); // Calculates gravity for player
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex; // Calculates jump velocity for player

        SetHealth(m_healthMax); // sets health for player

        //Get child with the renderer
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            if (this.gameObject.transform.GetChild(i).GetComponentInChildren<SkinnedMeshRenderer>() != null)
                m_childRenderer = this.gameObject.transform.GetChild(i).gameObject;
        }
    }

    public override void CharaterActions() // update function
    {
        //Stop crashes due to delta time being set to 0.0f
        if (Time.timeScale == 0.0f)
            return;

        Vector2 input = new Vector2(XCI.GetAxisRaw(XboxAxis.LeftStickX, controller), XCI.GetAxisRaw(XboxAxis.LeftStickY, controller)); // Gets left and right input for player

        if (IsDead()) // Checks if player is dead
        {
            input = new Vector2(0, 0); // if dead players input is set to null
        }

        if(pController.m_CollisionInfo.bottom) // checks if player is grounded
        {
            jumpDelayTimer = jumpDelay; // resets jump delay timer
        }
        jumpDelayTimer -= Time.deltaTime; // Updates jump delay timer

        int wallDirX = (pController.m_CollisionInfo.left) ? -1 : 1; // Checks which direction the player is colliding with wall

        float targetVelocityX = input.x * moveSpeed; // sets target velocity from input and current velocity
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (pController.m_CollisionInfo.bottom) ? accelerationTimeGrounded : accelerationTimeAirborne); //sets acceleration in air and grounded

        bool wallSliding = false; // sets wallSliding to false
        if ((pController.m_CollisionInfo.left || pController.m_CollisionInfo.right) && !pController.m_CollisionInfo.bottom && !IsDead()) //checks if wallsliding and alive
        {
            wallSliding = true; // sets wall sliding to true

            if (velocity.y < -wallSlideSpeedMax) // Keeps wallSlideSpeed to below maximum
            {
                velocity.y = -wallSlideSpeedMax;
            }

            
        }

        if (pController.m_CollisionInfo.top || pController.m_CollisionInfo.bottom) // If hitting roof or ground stop any vertical velocity
        {
            velocity.y = 0;
        }



        if (XCI.GetButtonDown(jumpButton, controller) && !IsDead()) // Checks if pressing button A and alive
        {
            if (wallSliding) // Checks if wallSliding
            {
                    velocity.x = -wallDirX * wallLeap.x; // Preforms wall leap
                    velocity.y = wallLeap.y; // Preforms wall leap
            }
            if (pController.m_CollisionInfo.bottom || jumpDelayTimer > 0) // Checks if time for delayed jump
            {
                velocity.y = jumpVelocity;
            }
        }

        if(velocity.x > 0) // Rotates character 
        {
            m_childRenderer.transform.rotation = (Quaternion.Euler(0, 90, 0));
        }
        if(velocity.x < 0) // rotates character
        {
            m_childRenderer.transform.rotation = (Quaternion.Euler(0, 270, 0));
        }

        velocity.y += gravity * Time.deltaTime; // sets velocity
        pController.Move(velocity * Time.deltaTime); // calls move function from player controller
    }
}
