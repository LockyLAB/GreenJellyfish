using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableEnviromentParent : MonoBehaviour
{
    protected List<GameObject> m_children= new List<GameObject>();
    public GameObject m_ray = null;

    public GameObject m_destructionSound = null;

    public GameObject m_destroyEffect = null;
    public Vector3 m_destroyEffectOffset = Vector3.zero;

    //--------------------------------------------------------------------------------------
    // Add a object to the child list for future reference
    //
    // Param:
    //		child: object to add to child list
    //--------------------------------------------------------------------------------------
    public void AddChild(GameObject child)
    {
        m_children.Add(child);
    }

    //--------------------------------------------------------------------------------------
    // Remove a object from the child
    //
    // Param:
    //		child: object to remove from child list
    //--------------------------------------------------------------------------------------
    public void RemoveChild(GameObject child)
    {
        int index = m_children.IndexOf(child);
        m_children.RemoveAt(index);
    }

    //--------------------------------------------------------------------------------------
    // Update
    // Check if child list is empty, if so destroy
    //--------------------------------------------------------------------------------------
    public virtual void Update()
    {
        if (m_children.Count == 0)
        {
            if(m_ray != null)
            {
                Destroy(m_ray);
                if (m_destroyEffect != null)
                    Destroy(Instantiate(m_destroyEffect, transform.TransformPoint(m_destroyEffectOffset), Quaternion.identity), 5.0f);

                if (m_destroyEffect != null)
                {
                    GameObject destructionSound = Instantiate(m_destructionSound, Vector3.zero, Quaternion.identity);
                    destructionSound.transform.localPosition = Vector3.zero;
                    destructionSound.GetComponent<AudioSource>().Play();
                    Destroy(destructionSound, 5.0f);
                }
            }
        }
    }
}
