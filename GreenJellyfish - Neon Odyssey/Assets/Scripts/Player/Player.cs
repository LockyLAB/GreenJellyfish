using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

[RequireComponent (typeof (PlayerController))]
public class Player : MonoBehaviour {

    public float moveSpeed = 10;
    public float gravity = -35;
    public float jumpVelocity = 10;


    public Vector2 wallClimb;
    public Vector2 wallDrop;
    public Vector2 wallLeap;

    bool isFalling = false;
    bool isSticking = false;
    float wallDropTime = 0.0f;


    float accelerationTime = 0.1f;
    float accelerationTimeAir = 0.25f;
    float velocityXSmoothing;

    Vector2 m_Velocity;

    public Camera cam1;

    public Material redPlayer;
    public Material bluePlayer;

    bool isRed = true;

    int health = 4;



	PlayerController m_Controller;

	void Start()
    {
        m_Controller = GetComponent<PlayerController> ();
        cam1 = GetComponent<Camera>();

        GetComponent<Renderer>().material = redPlayer;
        

        
    }
 

    void Update()
    {
   
        
        Vector2 input = new Vector2(XCI.GetAxisRaw(XboxAxis.LeftStickX), XCI.GetAxisRaw(XboxAxis.LeftStickY));

        int wallDirX = (m_Controller.m_CollisionInfo.left)? -1 : 1;

        float targetVelocityX = input.x * moveSpeed;
        m_Velocity.x = Mathf.SmoothDamp(m_Velocity.x, targetVelocityX, ref velocityXSmoothing, (m_Controller.m_CollisionInfo.bottom) ? accelerationTime : accelerationTimeAir);




            if (m_Controller.m_CollisionInfo.top || m_Controller.m_CollisionInfo.bottom)
        {
            m_Velocity.y = 0;
        }






      

   


        m_Velocity.y += gravity * Time.deltaTime;

       


        if ((m_Controller.m_CollisionInfo.left || m_Controller.m_CollisionInfo.right) && !m_Controller.m_CollisionInfo.bottom && m_Velocity.y != 0)
        {
            isSticking = true;
            m_Velocity.y = 0;

        }
        else
        {
            isSticking = false;
        }

        if (XCI.GetButtonDown(XboxButton.RightBumper) || XCI.GetAxisRaw(XboxAxis.RightTrigger) != 0)
        {
            if (isSticking && !isFalling)
            {
                

                if ((wallDirX < 0 && input.x < 0) || (wallDirX > 0 && input.x > 0))
                {
                    m_Velocity.x = -wallDirX * wallClimb.x;
                    m_Velocity.y = wallClimb.y;
                    wallDropTime = 0.0f;
                }
                else if (input.x == 0)
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


        if (m_Controller.m_CollisionInfo.bottom)
        {
            isFalling = false;
        }

        m_Controller.Move(m_Velocity * Time.deltaTime);



    }




}
