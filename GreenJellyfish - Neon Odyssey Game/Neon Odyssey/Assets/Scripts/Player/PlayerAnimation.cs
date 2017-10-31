﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    //Effects
    //Setting up landing effect
    private bool m_inAir = true;

    public GameObject m_landingEffect = null;
    public Vector3 m_landingEffectSpawnPos = Vector3.up * 0.1f;

    Animator m_animator = null;
    PlayerController m_playerController = null;

    // Use this for initialization
    void Start ()
    {
        m_animator = gameObject.GetComponent<Animator>();

        m_playerController = GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Landing animation
        if (m_inAir)
        {
            if (m_playerController.m_CollisionInfo.bottom) // Hit ground
            {
                Instantiate(m_landingEffect, transform.TransformPoint(m_landingEffectSpawnPos), Quaternion.identity);
                m_inAir = false;
            }
        }
        else
        {
            if (!m_playerController.m_CollisionInfo.bottom) //Just jumped
            {
                m_inAir = true;
            }
        }


    }
}
