using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class PlayerSounds : MonoBehaviour
{
	//Sound effects - store all sounds for use by other classes
	public GameObject m_movementAudio = null;
	public GameObject m_jumpingAudio = null;
	public GameObject m_firingGunAudio = null;
	public GameObject m_deathAudio = null;
	public GameObject m_reviveAudio = null;
	public GameObject m_respawnAudio = null;
    public GameObject m_wallJumpAudio = null;
    public GameObject m_wallSlideAudio = null;

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

        if (m_wallJumpAudio != null)
        {
            m_wallJumpAudio = Instantiate(m_wallJumpAudio, Vector3.zero, Quaternion.identity, gameObject.transform);
            m_wallJumpAudio.transform.localPosition = Vector3.zero;
        }

        if (m_wallSlideAudio != null)
        {
            m_wallSlideAudio = Instantiate(m_wallSlideAudio, Vector3.zero, Quaternion.identity, gameObject.transform);
            m_wallSlideAudio.transform.localPosition = Vector3.zero;
        }
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
        if (m_firingGunAudio != null)
            m_firingGunAudio.GetComponent<AudioSource>().volume = 0;
        if (m_deathAudio != null)
            m_deathAudio.GetComponent<AudioSource>().volume = 0;
        if (m_reviveAudio != null)
            m_reviveAudio.GetComponent<AudioSource>().volume = 0;
        if (m_respawnAudio != null)
            m_respawnAudio.GetComponent<AudioSource>().volume = 0;
        if (m_wallJumpAudio != null)
            m_wallJumpAudio.GetComponent<AudioSource>().volume = 0;
        if (m_wallSlideAudio != null)
            m_wallSlideAudio.GetComponent<AudioSource>().volume = 0;
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
        if (m_firingGunAudio != null)
            m_firingGunAudio.GetComponent<AudioSource>().volume = 1;
        if (m_deathAudio != null)
            m_deathAudio.GetComponent<AudioSource>().volume = 1;
        if (m_reviveAudio != null)
            m_reviveAudio.GetComponent<AudioSource>().volume = 1;
        if (m_respawnAudio != null)
            m_respawnAudio.GetComponent<AudioSource>().volume = 1;
        if (m_wallJumpAudio != null)
            m_wallJumpAudio.GetComponent<AudioSource>().volume = 1;
        if (m_wallSlideAudio != null)
            m_wallSlideAudio.GetComponent<AudioSource>().volume = 1;
    }
}
