using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject m_target = null;
    public float m_forwardSpeed = 0.0f;

    public BehaviourBase m_initalBehaviour;

    // Use this for initialization
    void Awake ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        BehaviourBase.BehaviourStatus State = m_initalBehaviour.Execute();
    }
}
