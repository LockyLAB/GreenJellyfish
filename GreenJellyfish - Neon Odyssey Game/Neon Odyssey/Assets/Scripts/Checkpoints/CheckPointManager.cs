using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Edward,
//-contributors:
//---------------------------------------------------------

//--------------------------------------------------------------
// Attach script to CHECKPOINT MANAGER prefab
//--------------------------------------------------------------

public class CheckPointManager : MonoBehaviour
{

    public Vector3 currentCheckpoint = Vector3.zero;


   // holds data on current checkpoint
    public void setCurrentCheckpoint(Vector3 pos)
    {
        currentCheckpoint = pos;
    }
}
