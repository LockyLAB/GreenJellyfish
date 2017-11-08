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
    public Vector3 m_deathEffectSpawnPos = Vector3.up * 0.5f;

    //Sounds
    public AudioSource m_movementAudio = null;
    public AudioSource m_firingGunAudio = null;
    public AudioSource m_firingLaserAudio = null;
    public AudioSource m_deathAudio = null;

    private GameObject m_childRenderer = null; // gets renderer for child

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public Difficulty m_difficulty = Difficulty.Easy;

    void Start()
    {
        //Get child with the renderer
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            if (this.gameObject.transform.GetChild(i).GetComponentInChildren<SkinnedMeshRenderer>() != null)
                m_childRenderer = this.gameObject.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    public override void CharaterActions()
    {
        m_initalBehaviour.Execute();

        if (IsDead())
            PlayDeath();

        //if(GetComponent<EnemyBeetle>()!=null) // Beetle model was wrong way.....
        //{
        //    if (GetComponent<Rigidbody>().velocity.x > 0.01f) // Rotates character 
        //        m_childRenderer.transform.rotation = (Quaternion.Euler(0, 0, 0)); //Face forwards
        //    if (GetComponent<Rigidbody>().velocity.x < -0.01f) // rotates character
        //        m_childRenderer.transform.rotation = (Quaternion.Euler(0, 180, 0)); // Face backwards
        //}
        //else
        //{
            if (GetComponent<Rigidbody>().velocity.x > 0.01f) // Rotates character 
                m_childRenderer.transform.rotation = (Quaternion.Euler(0, 0, 0)); //Face forwards
            if (GetComponent<Rigidbody>().velocity.x < -0.01f) // rotates character
                m_childRenderer.transform.rotation = (Quaternion.Euler(0, 180, 0)); // Face backwards
        //}
        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.x)>0)
            gameObject.GetComponent<Animator>().SetBool("Moving", true);
        else
            gameObject.GetComponent<Animator>().SetBool("Moving", false);
    }

    public void PlayDeath()
    {
        if (m_deathEffect !=null)
            Destroy(Instantiate(m_deathEffect, transform.TransformPoint(m_deathEffectSpawnPos), Quaternion.identity),5.0f);
        GameObject.FindWithTag("GameController").GetComponent<PickupSystem>().GeneratePickup(this.gameObject);
        Destroy(gameObject);
    }
}
