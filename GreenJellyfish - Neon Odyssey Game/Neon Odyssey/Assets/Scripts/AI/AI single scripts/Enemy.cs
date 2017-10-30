using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Enemy : Character
{

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
    public override void CharaterActions()
    {
        //GetComponent<Rigidbody>().velocity = new Vector3(0.0f, GetComponent<Rigidbody>().velocity.y, 0.0f);
        m_initalBehaviour.Execute();

        if (IsDead())
            PlayDeath();
    }

    public void PlayDeath()
    {
        if (m_deathEffect !=null)
            Instantiate(m_deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
