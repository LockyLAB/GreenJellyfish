using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableEnviromentParent : MonoBehaviour
{
    protected List<GameObject> m_children= new List<GameObject>();
    public GameObject m_ray = null;

    public GameObject m_destroyEffect = null;
    public Vector3 m_destroyEffectOffset = Vector3.zero;


    public void AddChild(GameObject child)
    {
        m_children.Add(child);
    }

    public void RemoveChild(GameObject child)
    {
        int index = m_children.IndexOf(child);
        m_children.RemoveAt(index);
    }

    public virtual void Update()
    {
        if (m_children.Count == 0)
        {
            if(m_destroyEffect!=null)
                Destroy(Instantiate(m_destroyEffect, transform.TransformPoint(m_destroyEffectOffset), Quaternion.identity),5.0f);
            if(m_ray != null)
                Destroy(m_ray);
            Destroy(this.gameObject);
        }
    }
}
