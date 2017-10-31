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
        m_initalBehaviour.Execute();

        if (IsDead())
            PlayDeath();
    }

    public void PlayDeath()
    {
        if (m_deathEffect !=null)
            Instantiate(m_deathEffect, transform.position, Quaternion.identity);
        GameObject.FindWithTag("GameController").GetComponent<PickupSystem>().GeneratePickup(this.gameObject);
        Destroy(gameObject);
    }
}
