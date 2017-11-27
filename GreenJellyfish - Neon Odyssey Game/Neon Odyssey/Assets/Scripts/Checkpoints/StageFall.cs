using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Edward,
//-contributors:
//---------------------------------------------------------

//---------------------------------------------------
// 1. Attach this script to CHECKPOINT prefab
// 2. Plug in CHECKPOINT MANAGER gameobject from SCENE
//---------------------------------------------------

public class StageFall : MonoBehaviour
{

    public CheckPointManager CPmanager1;

    // spawn player at last touched checkpoint if they fall off stage
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<Player>())
        {
            other.gameObject.transform.position = CPmanager1.currentCheckpoint;
        }
    }
}
