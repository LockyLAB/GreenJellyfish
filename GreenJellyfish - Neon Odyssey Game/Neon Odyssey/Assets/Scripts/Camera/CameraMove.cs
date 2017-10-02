using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    private bool m_singlePlayer = false;

    private GameObject m_player1 = null;

    private GameObject m_player2 = null;

    public Vector3 offset = new Vector3(0, 1.0f, -10);

    // Use this for initialization
	void Awake ()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");

        //Assign player 1
        if (players[0].GetComponent<P1ColourController>() != null)
            m_player1 = players[0];
        else if (players[1].GetComponent<P1ColourController>() != null)
            m_player1 = players[1];

        //Assign player 1
        if (players[0].GetComponent<P2ColourController>() != null)
            m_player2 = players[0];
        else if (players[1].GetComponent<P2ColourController>() != null)
            m_player2 = players[1];

        if (m_player2 == null)
            m_singlePlayer = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(m_singlePlayer);

        //Zoom in offset

        //Single player
        if(m_singlePlayer)
            transform.position = m_player1.transform.position + offset;
        //Multiplayer
        else
        {
            //Zoom in offset
            float offsetZ = -(m_player1.transform.position - m_player2.transform.position).magnitude - 10;
            offsetZ = Mathf.Clamp(offsetZ, -20, -10);
            Debug.Log(offsetZ);
            offset.z = offsetZ;
            transform.position = (m_player1.transform.position + m_player2.transform.position) / 2 + offset;
        }
    }
}
