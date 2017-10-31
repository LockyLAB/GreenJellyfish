﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    private bool m_singlePlayer = false;

    private GameObject m_player1 = null;

    private GameObject m_player2 = null;

    public Vector3 offset = new Vector3(0, 1.0f, -10);

    public float m_zoomSpeed = 0.02f;

    public float m_horizontalBuffer = 10.0f;
    public float m_verticalBuffer = 7.0f;

    public float m_maxHorizontalDistance = 20.0f;
    public float m_maxVerticalDistance = 14.0f;

    // Use this for initialization
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

    // Update is called once per frame
    void Update ()
    {
        //Single player
        if (m_singlePlayer)
            transform.position = m_player1.transform.position + offset;
        //Multiplayer
        else
        {
            Vector3 cameraPos = transform.position;
            Vector3 distance = m_player1.transform.position - m_player2.transform.position;//Get distance between players

            //Compare distance to buffers
            if (Mathf.Abs(distance.x) > m_horizontalBuffer)
                cameraPos.x = (m_player1.transform.position.x + m_player2.transform.position.x) / 2 + offset.x;
            if (Mathf.Abs(distance.y) > m_verticalBuffer)
                cameraPos.y = (m_player1.transform.position.y + m_player2.transform.position.y) / 2 + offset.y;

            transform.position = cameraPos;
        }
    }
}
