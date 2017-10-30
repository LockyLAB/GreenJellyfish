using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    private bool m_singlePlayer = false;

    private GameObject m_player1 = null;

    private GameObject m_player2 = null;

    public Vector3 offset = new Vector3(0, 1.0f, -10);

    public float m_zoomMin = 10.0f;
    public float m_zoomSpeed = 0.02f;

    public float m_maxHorizontalDistance = 20.0f;
    public float m_maxVerticalDistance = 14.0f;

    // Use this for initialization
    void Start ()
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
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Single player
        if (m_singlePlayer)
            transform.position = m_player1.transform.position + offset;
        //Multiplayer
        else
            transform.position = (m_player1.transform.position + m_player2.transform.position) / 2 + offset;
    }
}
