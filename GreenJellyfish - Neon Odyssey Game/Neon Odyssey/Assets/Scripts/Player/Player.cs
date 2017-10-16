using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{

    public float maxJumpHeight = 4;

    public float timeToJumpApex = 0.4f;



    public float moveSpeed = 10;
    public float gravity;

    private float maxJumpVelocity = 10;



    public Vector2 wallClimb = new Vector2(7.5f, 14);
    public Vector2 wallDrop = new Vector2(8, 5);
    public Vector2 wallLeap = new Vector2(8, 14);

    bool isFalling;
    bool isSticking = false;
    public float wallDropTime = 0.0f;


    float accelerationTime = 0.1f;
    float accelerationTimeAir = 0.25f;
    float velocityXSmoothing;

    public XboxController controller;

    Vector2 m_Velocity;


    public bool isDead = false;

    PlayerController m_Controller;






    void Start()
    {
        m_Controller = GetComponent<PlayerController>();



        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;



    }


    void Update()
    {




        Vector2 leftInput = new Vector2(XCI.GetAxisRaw(XboxAxis.LeftStickX, controller), XCI.GetAxisRaw(XboxAxis.LeftStickY, controller));
        if (isDead)
        {
            leftInput = Vector2.zero;
        }

        int wallDirX = (m_Controller.m_CollisionInfo.left) ? -1 : 1;

        float targetVelocityX = leftInput.x * moveSpeed;
        m_Velocity.x = Mathf.SmoothDamp(m_Velocity.x, targetVelocityX, ref velocityXSmoothing, (m_Controller.m_CollisionInfo.bottom) ? accelerationTime : accelerationTimeAir);




        if (m_Controller.m_CollisionInfo.top || m_Controller.m_CollisionInfo.bottom)
        {
            m_Velocity.y = 0;
        }



        m_Velocity.y += gravity * Time.deltaTime;




        if ((m_Controller.m_CollisionInfo.left || m_Controller.m_CollisionInfo.right) && !m_Controller.m_CollisionInfo.bottom && m_Velocity.y != 0 && !isFalling && !isDead)
        {
            isSticking = true;
            m_Velocity.y = 0;

        }
        else
        {
            isSticking = false;
        }

        if (XCI.GetButtonDown(XboxButton.A, controller) && !isDead || XCI.GetButtonDown(XboxButton.A, controller) && !isDead)
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
                m_Velocity.y = maxJumpVelocity;
            }

        }

        if (m_Controller.m_CollisionInfo.bottom)
        {
            isFalling = false;
        }

        if (isSticking && !isDead)
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



        //if (Physics.Raycast(this.transform.position, Vector3.down, LayerMask.GetMask("Platform")))
        //{
        //    if (XCI.GetAxisRaw(XboxAxis.LeftTrigger, controller) > 0 && !isDead && XCI.GetAxis(XboxAxis.LeftStickY, controller) < -0.1 || XCI.GetAxisRaw(XboxAxis.RightTrigger, controller) > 0 && !isDead && XCI.GetAxis(XboxAxis.LeftStickY, controller) < -0.1)
        //    {
        //        this.transform.Translate(Vector3.down * 0.2f);
        //    }
        //}


        m_Controller.Move(m_Velocity * Time.deltaTime);

    }




}
