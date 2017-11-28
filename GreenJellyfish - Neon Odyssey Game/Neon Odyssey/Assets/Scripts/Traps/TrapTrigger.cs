using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class TrapTrigger : MonoBehaviour {

    public List<TrapBase> m_activateTraps;
    public List<TrapBase> m_deactivateTraps;

    //--------------------------------------------------------------------------------------
    // On trigger enter
    // case of player:
    //      activate all triggers in activate list
    //      disable all traps in deactivate list
    //
    // Param:
    //		other: collider
    //--------------------------------------------------------------------------------------
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
