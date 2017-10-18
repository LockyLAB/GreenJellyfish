using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{

    public float jumpHeight = 18; // Jump height of player
    // public float timeToJumpApex = .4f; // time taken till player reaches jump height
    public float accelerationTimeAirborne = .4f; // acceleration of movement in air
    public float accelerationTimeGrounded = .02f; // Acceleration of movement on the ground
    public float moveSpeed = 12; // movement speed

    public Vector2 wallJumpClimb; // x and y velocity of wall climb
    public Vector2 wallJumpOff; // x and y velocity of wall jump off
    public Vector2 wallLeap; // X and y velocity of wall leap

    public float wallSlideSpeedMax = 0; // velocity of sliding down walls
    public float wallStickTime = 0.0f; // How long you stick to wall before you can jump off it 
    float timeToWallUnstick; 

    public float gravity = -50; // Gravity
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing; // Acceleration on ground and in air

    PlayerController pController; // Reference to player controller

    public bool isFirstPlayer; // Checks which player it is

    public XboxController controller; // Checks which controller it is

    public bool isDead; // Checks if player is dead
    void Start()
    {
        pController = GetComponent<PlayerController>();

        //jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    void Update()
    {

            Vector2 input = new Vector2(XCI.GetAxisRaw(XboxAxis.LeftStickX, controller), XCI.GetAxisRaw(XboxAxis.LeftStickY, controller)); // Sets the horizontal input for the player
            if (isDead) // checks if the player is dead
            {
                input = new Vector2(0, 0); // Sets input to zero if player is dead
            }

            int wallDirX = (pController.m_CollisionInfo.left) ? -1 : 1; // Checks the direction of walls if there is a collision

            float targetVelocityX = input.x * moveSpeed;
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (pController.m_CollisionInfo.bottom) ? accelerationTimeGrounded : accelerationTimeAirborne); // Changes acceleration on ground and in air

            bool wallSliding = false; // sets wallSliding to false
            if ((pController.m_CollisionInfo.left || pController.m_CollisionInfo.right) && !pController.m_CollisionInfo.bottom && !isDead) // Checks if the player is wallsliding
            {
                wallSliding = true; // Sets wallsliding to true

                if (velocity.y < -wallSlideSpeedMax) // Adds vertical velocity to the player based on wall slide speed
                {
                    velocity.y = -wallSlideSpeedMax;
                }


            }

            if (pController.m_CollisionInfo.top || pController.m_CollisionInfo.bottom) // If player collides above or below 
            {
                velocity.y = 0; // set velocity to zero
            }



            if (XCI.GetButtonDown(XboxButton.A, controller) && !isDead) // if pressing a and not dead
            {
                if (wallSliding) // Checks if wallsliding
                {
                    velocity.x = -wallDirX * wallLeap.x; // If wallsliding leap off when pressing A
                    velocity.y = wallLeap.y; 
                }
                if (pController.m_CollisionInfo.bottom) // If touching the ground
                {
                    velocity.y = jumpHeight; // Jump normally based on jump height
                }
            }


            velocity.y += gravity * Time.deltaTime; // Sets gravity to player
            pController.Move(velocity * Time.deltaTime); // Calls move function on player

        }
    
}
