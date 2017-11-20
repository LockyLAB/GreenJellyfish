using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayshieldTrigger : MonoBehaviour {

    public GameObject boss;

    public GameObject m_bossCameraSnap = null;

    public GameObject shield;
    private bool triggered;

    void Start()
    {
        //shield.SetActive(true);
        triggered = false;
    }
    // Update is called once per frame
    void Update () {
        
        if (!triggered)
        {
            if (boss == null)
            {
                shield.SetActive(false);
                triggered = true;

                //Lock camera
                m_bossCameraSnap.GetComponent<BossRoomSnap>().Deactivate();
            }
        }
	}

}
