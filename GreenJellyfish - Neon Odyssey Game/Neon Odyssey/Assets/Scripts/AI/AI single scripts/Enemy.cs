using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

[RequireComponent (typeof(CapsuleCollider))]
public class Enemy : Character
{
	public float m_forwardSpeed = 0.0f;

	//Audio
	public GameObject m_movementAudio = null;
	public GameObject m_jumpingAudio = null;
	public GameObject m_landingAudio = null;
	public GameObject m_firingLaserAudio = null;
	public GameObject m_firingGunAudio = null;
	public GameObject m_deathAudio = null;

	[HideInInspector]
	public BehaviourBase m_initalBehaviour;
	[HideInInspector]
	public GameObject m_target = null;

	public GameObject m_deathEffect = null;
	public Vector3 m_deathEffectSpawnPos = Vector3.up * 0.5f;

	public enum Difficulty
	{
		Easy,
		Medium,
		Hard
	}

	public Difficulty m_difficulty = Difficulty.Easy;

    //--------------------------------------------------------------------------------------
    // Awake
    // Initialise sound to spawn on object
    //--------------------------------------------------------------------------------------
    void Awake ()
	{
        //Set up audio
        if (m_movementAudio != null)
        {
            m_movementAudio = Instantiate(m_movementAudio, Vector3.zero, Quaternion.identity, gameObject.transform);
            m_movementAudio.transform.localPosition = Vector3.zero;
        }
        if (m_jumpingAudio != null)
        {
            m_jumpingAudio = Instantiate(m_jumpingAudio, Vector3.zero, Quaternion.identity, gameObject.transform);
            m_jumpingAudio.transform.localPosition = Vector3.zero;
        }
		if (m_landingAudio != null)
        {
            m_landingAudio = Instantiate(m_landingAudio, Vector3.zero, Quaternion.identity, gameObject.transform);
            m_landingAudio.transform.localPosition = Vector3.zero;
        }
		if (m_firingLaserAudio != null)
        {
            m_firingLaserAudio = Instantiate(m_firingLaserAudio, Vector3.zero, Quaternion.identity, gameObject.transform);
            m_firingLaserAudio.transform.localPosition = Vector3.zero;
        }
		if (m_firingGunAudio != null)
        {
            m_firingGunAudio = Instantiate(m_firingGunAudio, Vector3.zero, Quaternion.identity, gameObject.transform);
            m_firingGunAudio.transform.localPosition = Vector3.zero;
        }
	}

    //--------------------------------------------------------------------------------------
    // Update is called once per frame
    // Run AI behaviour
    //Face correct direction
    //--------------------------------------------------------------------------------------
    public override void CharaterActions ()
	{
		m_initalBehaviour.Execute ();

		if (IsDead ())
			PlayDeath ();

        //Movement functions
        if (m_childRenderer != null)
        {
            if (GetComponent<EnemyBeetle>() != null || GetComponent<EnemyBeetleTutorial>() != null)
            { // Beetle model was wrong way.....  :(
                if (GetComponent<Rigidbody>().velocity.x > 0.0f) // Rotates character 
                    m_childRenderer.transform.rotation = (Quaternion.Euler(0, 180, 0)); //Face forwards
                else if (GetComponent<Rigidbody>().velocity.x <= 0.0f) // rotates character
                    m_childRenderer.transform.rotation = (Quaternion.Euler(0, 0, 0)); // Face backwards
            }
            else
            {
                if (GetComponent<Rigidbody>().velocity.x > 0.0f) // Rotates character 
                    m_childRenderer.transform.rotation = (Quaternion.Euler(0, 0, 0)); //Face forwards
                else if (GetComponent<Rigidbody>().velocity.x <= 0.0f) // rotates character
                    m_childRenderer.transform.rotation = (Quaternion.Euler(0, 180, 0)); // Face backwards
            }
        }
	}

    //--------------------------------------------------------------------------------------
    // Perform death of enemy
    // Run animation then destroy
    //--------------------------------------------------------------------------------------
    public void PlayDeath ()
	{
		if (m_deathEffect != null)
			Destroy (Instantiate (m_deathEffect, transform.TransformPoint (m_deathEffectSpawnPos), Quaternion.identity), 5.0f);
		GameObject.FindWithTag ("GameController").GetComponent<PickupSystem> ().GeneratePickup (this.gameObject);

		GameObject deathSound = Instantiate (m_deathAudio, transform.position, Quaternion.identity);
		deathSound.GetComponent<AudioSource> ().Play ();
		Destroy (deathSound, 5.0f);
		Destroy (gameObject);
	}

    //--------------------------------------------------------------------------------------
    // Turn player volume to 0
    //--------------------------------------------------------------------------------------
    public void DisableSound()
    {
        if (m_movementAudio != null)
            m_movementAudio.GetComponent<AudioSource>().volume = 0;
        if (m_jumpingAudio != null)
            m_jumpingAudio.GetComponent<AudioSource>().volume = 0;
        if (m_landingAudio != null)
            m_landingAudio.GetComponent<AudioSource>().volume = 0;
        if (m_firingLaserAudio != null)
            m_firingLaserAudio.GetComponent<AudioSource>().volume = 0;
        if (m_firingGunAudio != null)
            m_firingGunAudio.GetComponent<AudioSource>().volume = 0;
        if (m_deathAudio != null)
            m_deathAudio.GetComponent<AudioSource>().volume = 0;
    }

    //--------------------------------------------------------------------------------------
    // Turn player sound volume to 1
    //--------------------------------------------------------------------------------------
    public void EnableSound()
    {
        if (m_movementAudio != null)
            m_movementAudio.GetComponent<AudioSource>().volume = 1;
        if (m_jumpingAudio != null)
            m_jumpingAudio.GetComponent<AudioSource>().volume = 1;
        if (m_landingAudio != null)
            m_landingAudio.GetComponent<AudioSource>().volume = 1;
        if (m_firingLaserAudio != null)
            m_firingLaserAudio.GetComponent<AudioSource>().volume = 1;
        if (m_firingGunAudio != null)
            m_firingGunAudio.GetComponent<AudioSource>().volume = 1;
        if (m_deathAudio != null)
            m_deathAudio.GetComponent<AudioSource>().volume = 1;
    }
}
