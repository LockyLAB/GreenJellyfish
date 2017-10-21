using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float m_forwardSpeed = 0.0f;

    //[HideInInspector]
    public BehaviourBase m_initalBehaviour;
    //[HideInInspector]
    public GameObject m_target = null;

    public GameObject m_deathEffect = null;
    public int m_health = 1;

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
        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, GetComponent<Rigidbody>().velocity.y, 0.0f);
        m_initalBehaviour.Execute();

        if (m_health <= 0)
            PlayDeath();
    }

    public void PlayDeath()
    {
        if (m_deathEffect !=null)
            Instantiate(m_deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
