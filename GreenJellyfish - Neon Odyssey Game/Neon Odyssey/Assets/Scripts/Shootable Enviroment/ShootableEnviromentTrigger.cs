using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableEnviromentTrigger : MonoBehaviour
{
    public GameObject m_parent = null;

    //--------------------------------------------------------------------------------------
    // Add object to parent child list
    //--------------------------------------------------------------------------------------
    private void Awake()
    {
        m_parent.GetComponent<ShootableEnviromentParent>().AddChild(this.gameObject); 
    }

    //--------------------------------------------------------------------------------------
    // When trigger is destroyed
    // Remove from parent
    //--------------------------------------------------------------------------------------
    public virtual void TriggerDestroy()
    {
        m_parent.GetComponent<ShootableEnviromentParent>().RemoveChild(this.gameObject);
        Destroy(this.gameObject);
    }
}
