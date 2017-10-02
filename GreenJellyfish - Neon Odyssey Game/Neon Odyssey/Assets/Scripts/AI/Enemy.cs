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
        Red = 0,
        Green = 1,
        Yellow = 2,
        Purple = 3
    }

    public Colour m_colour = Colour.Red;
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        BehaviourBase.BehaviourStatus State = m_initalBehaviour.Execute();
    }
}
