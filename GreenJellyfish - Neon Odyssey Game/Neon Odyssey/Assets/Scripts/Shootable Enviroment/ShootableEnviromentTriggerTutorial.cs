using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableEnviromentTriggerTutorial : ShootableEnviromentTrigger
{

    public GameObject m_destructionEffect = null;
    public float m_destructionEffectDuration = 0.0f;

    //--------------------------------------------------------------------------------------
    // When trigger is destroyed
    // Create destruction effect if its been set
    // keep alive for set durtation but be disabled
    //--------------------------------------------------------------------------------------
    public override void TriggerDestroy()
    {
        //Create destruction effect from object to parent
        GameObject destructionEffect = Instantiate(m_destructionEffect, transform.position, Quaternion.identity);
        //Face parent
        destructionEffect.transform.rotation = Quaternion.LookRotation(m_parent.transform.position - transform.position);
        
        Destroy(destructionEffect, m_destructionEffectDuration);

        //Set to invisible
        gameObject.SetActive(false);
        Invoke("RemoveFromParent", m_destructionEffectDuration); // Keep object alive till effect has finished
    }

    //--------------------------------------------------------------------------------------
    // Remove trigger from parent and destroy game object
    //--------------------------------------------------------------------------------------
    private void RemoveFromParent()
    {
        m_parent.GetComponent<ShootableEnviromentParent>().RemoveChild(this.gameObject);
        Destroy(this.gameObject);
    }
}
