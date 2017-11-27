using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

	//Sound effects - store all sounds for use by other classes
	public GameObject m_movementAudio = null;
	public GameObject m_jumpingAudio = null;
	public GameObject m_firingGunAudio = null;
	public GameObject m_deathAudio = null;
	public GameObject m_reviveAudio = null;
	public GameObject m_respawnAudio = null;

	PlayerController m_playerController = null;
	Player m_player = null;

	// Use this for initialization
	void Start ()
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
		if (m_firingGunAudio != null)
        {
            m_firingGunAudio = Instantiate(m_firingGunAudio, Vector3.zero, Quaternion.identity, gameObject.transform);
            m_firingGunAudio.transform.localPosition = Vector3.zero;
        }

		if (m_deathAudio != null)
        {
            m_deathAudio = Instantiate(m_deathAudio, Vector3.zero, Quaternion.identity, gameObject.transform);
            m_deathAudio.transform.localPosition = Vector3.zero;
        }

		if (m_reviveAudio != null)
        {
            m_reviveAudio = Instantiate(m_reviveAudio, Vector3.zero, Quaternion.identity, gameObject.transform);
            m_reviveAudio.transform.localPosition = Vector3.zero;
        }

        if (m_respawnAudio != null)
        {
            m_respawnAudio = Instantiate(m_respawnAudio, Vector3.zero, Quaternion.identity, gameObject.transform);
            m_respawnAudio.transform.localPosition = Vector3.zero;
        }

		//Set up shared components
		m_playerController = GetComponent<PlayerController> ();
		m_player = GetComponent<Player> ();
	}
}
