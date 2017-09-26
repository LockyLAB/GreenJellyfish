using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

[RequireComponent (typeof (PlayerController))]
public class Player : MonoBehaviour {

    public float moveSpeed = 10;
    public float gravity = -35;
    public float jumpVelocity = 10;


    public Vector2 wallClimb = new Vector2(7.5f, 14);
    public Vector2 wallDrop = new Vector2(8, 5);
    public Vector2 wallLeap = new Vector2(8, 14);

    bool isFalling;
    bool isSticking = false;
    float wallDropTime = 0.0f;


    float accelerationTime = 0.1f;
    float accelerationTimeAir = 0.25f;
    float velocityXSmoothing;

    Vector2 m_Velocity;

    bool isRed = true;

    int health = 4;

	PlayerController m_Controller;

	void Start()
    {
        m_Controller = GetComponent<PlayerController> ();

       
    }
 

    void Update()
    {
   
        
        Vector2 leftInput = new Vector2(XCI.GetAxisRaw(XboxAxis.LeftStickX), XCI.GetAxisRaw(XboxAxis.LeftStickY));
        
        int wallDirX = (m_Controller.m_CollisionInfo.left)? -1 : 1;

        float targetVelocityX = leftInput.x * moveSpeed;
        m_Velocity.x = Mathf.SmoothDamp(m_Velocity.x, targetVelocityX, ref velocityXSmoothing, (m_Controller.m_CollisionInfo.bottom) ? accelerationTime : accelerationTimeAir);




            if (m_Controller.m_CollisionInfo.top || m_Controller.m_CollisionInfo.bottom)
        {
            m_Velocity.y = 0;
        }



        m_Velocity.y += gravity * Time.deltaTime;

       


        if ((m_Controller.m_CollisionInfo.left || m_Controller.m_CollisionInfo.right) && !m_Controller.m_CollisionInfo.bottom && m_Velocity.y != 0 && !isFalling)
        {
            isSticking = true;
            m_Velocity.y = 0;

        }
        else
        {
            isSticking = false;
        }

        if (XCI.GetButtonDown(XboxButton.RightBumper) || XCI.GetAxisRaw(XboxAxis.RightTrigger) == 1)
        {
            if (isSticking && !isFalling)
            {
                

                if ((wallDirX < 0 && leftInput.x < 0) || (wallDirX > 0 && leftInput.x > 0))
                {
                    m_Velocity.x = -wallDirX * wallClimb.x;
                    m_Velocity.y = wallClimb.y;
                    wallDropTime = 0.0f;
                }
                else if (leftInput.x == 0)
                {
                    m_Velocity.x = -wallDirX * wallDrop.x;
                    m_Velocity.y = wallDrop.y;
                    wallDropTime = 0.0f;
                }
                else
                {
                    m_Velocity.x = -wallDirX * wallLeap.x;
                    m_Velocity.y = wallLeap.y;
                    wallDropTime = 0.0f;
                }
            }

            if (m_Controller.m_CollisionInfo.bottom)
            {
                m_Velocity.y = jumpVelocity;
            }

        }

        if (m_Controller.m_CollisionInfo.bottom)
        {
            isFalling = false;
        }

        if (isSticking)
        {
           
            wallDropTime += 1.0f * Time.deltaTime;

            if (wallDropTime >= 1)
            {
                m_Velocity.x = -wallDirX * wallDrop.x;
                m_Velocity.y = wallDrop.y;

                wallDropTime = 0.0f;

                isFalling = true;
            }

        }


       
        
        m_Controller.Move(m_Velocity * Time.deltaTime);

       



    }




}
