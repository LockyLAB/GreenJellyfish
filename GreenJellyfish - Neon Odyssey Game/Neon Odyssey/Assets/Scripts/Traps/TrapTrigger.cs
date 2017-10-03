using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour {

    public List<TrapBase> m_traps;
	// Use this for initialization
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach(TrapBase trap in m_traps)
            {
                trap.ActivateTrap();
            }
        }

    }
}
