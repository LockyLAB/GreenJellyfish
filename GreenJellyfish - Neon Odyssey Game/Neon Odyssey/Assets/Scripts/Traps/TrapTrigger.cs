using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour {

    public List<TrapBase> m_activateTraps;
    public List<TrapBase> m_deactivateTraps;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (TrapBase trap in m_activateTraps)
            {
                trap.ActivateTrap();
            }

            foreach (TrapBase trap in m_deactivateTraps)
            {
                trap.DeactivateTrap();
            }
        }

    }
}
