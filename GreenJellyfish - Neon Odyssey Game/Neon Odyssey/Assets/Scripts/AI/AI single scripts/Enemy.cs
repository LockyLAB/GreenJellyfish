using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float m_forwardSpeed = 0.0f;

    [HideInInspector]
    public BehaviourBase m_initalBehaviour;
    [HideInInspector]
    public GameObject m_target = null;
    public enum Colour
    {
        Pink = 0,
        Yellow = 1,
        Green = 2,
        Orange = 3
    }

    public Colour m_colour = Colour.Pink;

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
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        BehaviourBase.BehaviourStatus State = m_initalBehaviour.Execute();
    }
}
