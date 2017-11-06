﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableEnviromentParent : MonoBehaviour
{
    private List<GameObject> m_children= new List<GameObject>();
    public GameObject m_ray = null;

    public void AddChild(GameObject child)
    {
        m_children.Add(child);
    }

    public void RemoveChild(GameObject child)
    {
        int index = m_children.IndexOf(child);
        m_children.RemoveAt(index);
    }

    private void Update()
    {
        if (m_children.Count == 0 && m_ray != null)
            Destroy(m_ray);
    }
}
