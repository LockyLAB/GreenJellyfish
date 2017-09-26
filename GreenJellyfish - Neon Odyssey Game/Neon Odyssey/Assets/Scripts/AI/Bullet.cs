using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float m_lifetime = 10.0f;
	// Use this for initialization
	void Awake ()
    {
        Destroy(this.gameObject, m_lifetime);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("player hit");
            Destroy(this);
        }
    }
}
