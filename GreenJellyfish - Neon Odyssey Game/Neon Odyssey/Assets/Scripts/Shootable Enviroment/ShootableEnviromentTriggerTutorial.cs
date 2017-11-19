using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableEnviromentTriggerTutorial : ShootableEnviromentTrigger
{

    public GameObject m_destructionEffect = null;
    public float m_destructionEffectDuration = 0.0f;

    
    public override void TriggerDestroy()
    {
        //Create destruction effect from object to parent
        GameObject destructionEffect = Instantiate(m_destructionEffect, transform.position, Quaternion.identity);
        //Face parent
        destructionEffect.transform.rotation = Quaternion.LookRotation(m_parent.transform.position - transform.position);
        
        Destroy(destructionEffect, m_destructionEffectDuration);

        Invoke("RemoveFromParent", m_destructionEffectDuration);
    }

    private void RemoveFromParent()
    {
        m_parent.GetComponent<ShootableEnviromentParent>().RemoveChild(this.gameObject);
        Destroy(this.gameObject);
    }
}
