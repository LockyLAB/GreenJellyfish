using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    //--------------------------------------------------------------
    // 1. Attach script to CHECKPOINT MANAGER prefab
    //--------------------------------------------------------------

    public Vector3 currentCheckpoint = Vector3.zero;


   // holds data on current checkpoint
    public void setCurrentCheckpoint(Vector3 pos)
    {
        currentCheckpoint = pos;
    }
}
