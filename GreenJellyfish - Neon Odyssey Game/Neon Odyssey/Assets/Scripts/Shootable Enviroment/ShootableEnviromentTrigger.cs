using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableEnviromentTrigger : MonoBehaviour
{
    public GameObject m_parent = null;

    private void Awake()
    {
        m_parent.GetComponent<ShootableEnviromentParent>().AddChild(this.gameObject);
    }

    public void OnDestruction()
    {
        m_parent.GetComponent<ShootableEnviromentParent>().RemoveChild(this.gameObject);
        Destroy(this.gameObject);
    }
}
