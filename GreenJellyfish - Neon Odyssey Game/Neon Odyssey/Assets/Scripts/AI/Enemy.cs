using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float m_forwardSpeed = 0.0f;

    public BehaviourBase m_initalBehaviour;
    [HideInInspector]
    public GameObject m_target = null;
    public enum Symbol
    {
        Ankh = 1,
        Flail = 2,
        Lotus = 3,
        Shen = 4
    }

    public Symbol m_symbol = Symbol.Ankh;

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
