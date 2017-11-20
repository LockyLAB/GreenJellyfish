using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    private bool m_singlePlayer = false;

    private GameObject m_player1 = null;

    private GameObject m_player2 = null;

    public Vector3 offset = new Vector3(6.0f, 4.0f, -20);

    public float m_minZoomSpeed = 0.1f;

    public float m_horizontalBuffer = 3.0f;
    public float m_verticalBuffer = 5.0f;

    public float m_maxHorizontalDistance = 20.0f;
    public float m_maxVerticalDistance = 14.0f;

    //Camera shake 
    private bool m_shakeEnabled = false; //Is enabled

    public int m_shakeAmount = 10; //How many times to shake
    private int m_shakeAmountCount = 0;

    public float m_shakeErraticness = 0.05f; // How often it shakes
    private float m_shakeTimer = 0.0f;

    public float m_shakeMagnitude = 0.05f; // How far it shakes

    //Camera Lock Pos
    public bool m_cameraLocked = false;
    public Vector3 m_cameraLockPos = Vector3.zero;

    //-----------------------------------------------------
    // Assign player varibles
    //-----------------------------------------------------
    void Start()
    {
        //Assign players
        if (GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_singlePlayer)
        {
            m_singlePlayer = true;
            m_player1 = GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_player1;
        }
        else
        {
            m_player1 = GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_player1;
            m_player2 = GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_player2;
        }

        if (m_singlePlayer)
            transform.position = m_player1.transform.position + offset;
        else
            transform.position = (m_player1.transform.position + m_player2.transform.position) / 2 + offset;
    }

    //-----------------------------------------------------
    // Get cameras goal position
    //Move camera towards goal at varible speed
    //-----------------------------------------------------
    void Update ()
    {
        //Single player
        if (m_singlePlayer)
            transform.position = m_player1.transform.position + offset;
        //Multiplayer
        else
        {
            Vector3 cameraPos = transform.position;
            Vector3 playerDis = m_player2.transform.position - m_player1.transform.position;
            Vector3 cameraGoal = m_cameraLockPos;

            if(!m_cameraLocked) // No Boss room camera lock
                cameraGoal = ((m_player1.transform.position + m_player2.transform.position) / 2) + offset;

            Vector3 cameraGoalDistance = cameraGoal - cameraPos;

            float zoomSpeed = 0.0f;

            //Compare distance to buffers
            if (Mathf.Abs(cameraGoalDistance.x) > m_horizontalBuffer) //Horizontal camera movement
            {
                float xVal = Mathf.Abs(playerDis.x) - m_horizontalBuffer;
                zoomSpeed = 8 / (m_maxHorizontalDistance * m_maxHorizontalDistance);
                cameraPos.x += ((zoomSpeed * (xVal * xVal)) + m_minZoomSpeed) * cameraGoalDistance.x * Time.deltaTime;
            }

            if (Mathf.Abs(cameraGoalDistance.y) > m_verticalBuffer) //Vertical camera movement
            {
                float yVal = Mathf.Abs(playerDis.y) - m_verticalBuffer;
                zoomSpeed = 8 / (m_maxVerticalDistance * m_maxVerticalDistance);
                cameraPos.y += ((zoomSpeed * (yVal * yVal)) + m_minZoomSpeed) * cameraGoalDistance.y * Time.deltaTime;
            }

            //Always apply z movement
            zoomSpeed = 0.05f;
            cameraPos.z += (zoomSpeed + m_minZoomSpeed) * cameraGoalDistance.z * Time.deltaTime;

            transform.position = cameraPos;
        }

        if (m_shakeEnabled)
            CameraShake();
    }

    //--------------------------------------------------------------------------------------
    // Enable the camera shake
    //--------------------------------------------------------------------------------------
    public void EnableCameraShake()
    {
        m_shakeEnabled = true;
    }

    //-----------------------------------------------------
    // Shake cmaera in random directions
    //Shakiness based off time between shakes, how much movement, and amount of shakes
    //-----------------------------------------------------
    void CameraShake()
    {
        m_shakeTimer -= Time.deltaTime;
        if(m_shakeTimer < 0.0f)
        {
            transform.position += new Vector3(Random.Range(-m_shakeMagnitude, m_shakeMagnitude), Random.Range(-m_shakeMagnitude, m_shakeMagnitude), 0.0f);
            m_shakeTimer = m_shakeErraticness;
            m_shakeAmountCount++;
        }

        if(m_shakeAmountCount > m_shakeAmount)
        {
            m_shakeAmountCount = 0;
            m_shakeEnabled = false;
        }
    }
}
