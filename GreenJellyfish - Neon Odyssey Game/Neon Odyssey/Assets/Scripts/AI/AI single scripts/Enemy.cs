﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float m_forwardSpeed = 0.0f;

    [HideInInspector]
    public BehaviourBase m_initalBehaviour;
    [HideInInspector]
    public GameObject m_target = null;

    public GameObject m_deathEffect = null;

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public Difficulty m_difficulty = Difficulty.Easy;

    // Update is called once per frame
    void Update ()
    {
        //GetComponent<Rigidbody>().velocity = new Vector3(0.0f,-9.8f,0.0f);
        BehaviourBase.BehaviourStatus State = m_initalBehaviour.Execute();
    }

    public void PlayDeath()
    {
        if (m_deathEffect !=null)
        {
            Instantiate(m_deathEffect, transform.position, Quaternion.identity);
            Destroy(this);
        }
    }
}
