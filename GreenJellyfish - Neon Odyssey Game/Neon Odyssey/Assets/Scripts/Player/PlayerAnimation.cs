using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    //Effects
    //Setting up landing effect
    private bool m_inAir = true;

    public List<GameObject> m_landingEffect;
    public Vector3 m_landingEffectSpawnPos = Vector3.up * 0.1f;

    public List<GameObject> m_jumpingEffect;
    public Vector3 m_jumpingEffectSpawnPos = Vector3.up * 0.1f;

    Animator m_animator = null;
    PlayerController m_playerController = null;

    // Use this for initialization
    void Start ()
    {
        m_animator = gameObject.GetComponentInChildren<Animator>();

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
                if(GetComponent<ColourController>().m_firstBulletSlot)
                    Destroy(Instantiate(m_landingEffect[0], transform.TransformPoint(m_landingEffectSpawnPos), Quaternion.identity, transform),1.0f);
                else
                    Destroy(Instantiate(m_landingEffect[1], transform.TransformPoint(m_landingEffectSpawnPos), Quaternion.identity, transform), 1.0f);
                m_inAir = false;
            }
        }
        else
        {
            if (!m_playerController.m_CollisionInfo.bottom) //Just jumped
            {
                if (GetComponent<ColourController>().m_firstBulletSlot)
                    Destroy(Instantiate(m_jumpingEffect[0], transform.TransformPoint(m_jumpingEffectSpawnPos), Quaternion.identity, transform), 1.0f);
                else
                    Destroy(Instantiate(m_jumpingEffect[1], transform.TransformPoint(m_jumpingEffectSpawnPos), Quaternion.identity, transform), 1.0f);

                m_inAir = true;
            }
        }

        if (Mathf.Abs(GetComponent<Player>().velocity.x) > 0 && m_playerController.m_CollisionInfo.bottom)
            m_animator.SetBool("Moving", true);
        else
            m_animator.SetBool("Moving", false);

        if (!m_playerController.m_CollisionInfo.bottom && !m_playerController.m_CollisionInfo.top && !m_playerController.m_CollisionInfo.left && !m_playerController.m_CollisionInfo.right)
            m_animator.SetBool("Jumping", true);
        else
            m_animator.SetBool("Jumping", false);
    }
}
