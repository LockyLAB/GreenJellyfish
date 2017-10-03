using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    private bool m_singlePlayer = false;

    private GameObject m_player1 = null;

    private GameObject m_player2 = null;

    public Vector3 offset = new Vector3(0, 1.0f, -10);

    public GameObject m_cameraWall = null;
    private float m_wallRightOffset = 10.0f;
    private float m_wallUpOffset = 6.0f;
    // T = top, B = Bottom, R = Right, L = Left 

    private GameObject m_cameraWallR;
    private GameObject m_cameraWallL;
    private GameObject m_cameraWallT;
    private GameObject m_cameraWallB;

    // Use this for initialization
    void Awake ()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");


        if(players.Length == 1)
        {
            m_player1 = players[0];
        }
        else if(players.Length == 2)
        {
 
            m_player1 = players[0];

            m_player2 = players[1];
        }

        if (m_player2 == null)
            m_singlePlayer = true;

        //Create camera walls
        if (m_cameraWall != null)
        {
            m_cameraWallR = Instantiate(m_cameraWall, Vector3.right * m_wallRightOffset, Quaternion.identity);
            m_cameraWallL = Instantiate(m_cameraWall, Vector3.left * m_wallRightOffset, Quaternion.identity);
            m_cameraWallT = Instantiate(m_cameraWall, Vector3.up * m_wallUpOffset, Quaternion.identity);
            m_cameraWallB = Instantiate(m_cameraWall, Vector3.down * m_wallUpOffset, Quaternion.identity);

            m_cameraWallT.transform.localScale = new Vector3(2 * m_wallRightOffset, 1.0f, 1.0f);
            m_cameraWallB.transform.localScale = new Vector3(2 * m_wallRightOffset, 1.0f, 1.0f);

            m_cameraWallL.transform.localScale = new Vector3(1.0f, 2 * m_wallUpOffset, 1.0f);
            m_cameraWallR.transform.localScale = new Vector3(1.0f, 2 * m_wallUpOffset, 1.0f);
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
        {
            //Zoom in offset
            float offsetZ = -0.5f * (m_player1.transform.position - m_player2.transform.position).magnitude - 10;
            offsetZ = Mathf.Clamp(offsetZ, -20, -10);

            offset.z = offsetZ;
            transform.position = (m_player1.transform.position + m_player2.transform.position) / 2 + offset;

            if (m_cameraWall != null)
            {
                //Move walls
                m_cameraWallR.transform.position = transform.position + Vector3.right * m_wallRightOffset + Vector3.forward * -offsetZ;
                m_cameraWallL.transform.position = transform.position + Vector3.left * m_wallRightOffset + Vector3.forward * -offsetZ;

                m_cameraWallT.transform.position = transform.position + Vector3.up * m_wallUpOffset + Vector3.forward * -offsetZ;
                m_cameraWallB.transform.position = transform.position + Vector3.down * m_wallUpOffset + Vector3.forward * -offsetZ;
            }
        }
    }
}
