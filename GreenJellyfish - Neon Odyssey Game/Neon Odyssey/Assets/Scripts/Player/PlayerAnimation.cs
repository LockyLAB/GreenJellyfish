using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;


//---------------------------------------------------------
//-written by: Sam,
//-contributors: Edward,
//---------------------------------------------------------

public class PlayerAnimation : MonoBehaviour
{
	//Effects
	//Setting up effects
	private bool m_inAir = true;
	private bool m_hitWall = true;

	//Store current effect
	private GameObject m_currentLandingEffect = null;
	private GameObject m_currentHitWallEffect = null;

	//store possible effects for each player
	public List<GameObject> m_landingEffect;
	public List<GameObject> m_hitWallEffect;

	//Effect offset
	public Vector3 m_landingEffectSpawnPos = Vector3.up * 0.1f;
	public Vector3 m_hitWallEffectSpawnPos = Vector3.up * 0.1f;

	public List<GameObject> m_jumpingEffect;
	public Vector3 m_jumpingEffectSpawnPos = Vector3.up * 0.1f;

	//Player components
	Animator m_animator = null;
	private PlayerSounds m_playerSounds = null;
	PlayerController m_playerController = null;
	Player m_player = null;

	// Use this for initialization
	void Start ()
	{
		m_animator = gameObject.GetComponentInChildren<Animator> ();

		m_playerSounds = GetComponent<PlayerSounds> ();

		m_playerController = GetComponent<PlayerController> ();
		m_player = GetComponent<Player> ();
	}

    //--------------------------------------------------------------------------------------
    // Play animation/sounds based of current inputs and outside varibles
    //--------------------------------------------------------------------------------------
    void Update ()
	{
        //Disable player input
        if (GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_inputOn == false)
            return;

        if (XCI.GetButtonDown(m_player.jumpButton, m_player.controller))
        {
            if (m_playerController.m_CollisionInfo.left || m_playerController.m_CollisionInfo.right)
            {
                if (!m_playerSounds.m_wallJumpAudio.GetComponent<AudioSource>().isPlaying)
                    m_playerSounds.m_wallJumpAudio.GetComponent<AudioSource>().Play();
            }

        }


            //Landing animation
        if (m_inAir) {
			if (m_playerController.m_CollisionInfo.bottom) { // Hit ground
				if (GetComponent<ColourController> ().m_firstBulletSlot)
					m_currentLandingEffect = Instantiate (m_landingEffect [0], transform.TransformPoint (m_landingEffectSpawnPos), Quaternion.identity, transform);
				else
					m_currentLandingEffect = Instantiate (m_landingEffect [1], transform.TransformPoint (m_landingEffectSpawnPos), Quaternion.identity, transform);

				StartCoroutine (PauseEffectFollow (0.1f, m_currentLandingEffect));
				m_inAir = false;
			}
		} else {
            if (XCI.GetButtonDown(m_player.jumpButton, m_player.controller))
            { //Just jumped
                if (m_currentLandingEffect != null)
                {//If player is no longer grounded remove the following effect
                    m_currentLandingEffect.transform.parent = null;
                }
                //Play Audio for jumping
                m_playerSounds.m_jumpingAudio.GetComponent<AudioSource>().Play();

            }
			if (!m_playerController.m_CollisionInfo.bottom) {
				if (GetComponent<ColourController> ().m_firstBulletSlot)
					Destroy (Instantiate (m_jumpingEffect [0], transform.TransformPoint (m_jumpingEffectSpawnPos), Quaternion.identity, transform), 1.0f);
				else
					Destroy (Instantiate (m_jumpingEffect [1], transform.TransformPoint (m_jumpingEffectSpawnPos), Quaternion.identity, transform), 1.0f);

				m_inAir = true;
			}
		}

		if (Mathf.Abs (GetComponent<Player> ().velocity.x) > 0.1f && m_playerController.m_CollisionInfo.bottom) { //moving animation
			m_animator.SetBool ("Moving", true);

			
            if(m_playerSounds != null)//Play Audio for moving
                if (!m_playerSounds.m_movementAudio.GetComponent<AudioSource>().isPlaying)
				    m_playerSounds.m_movementAudio.GetComponent<AudioSource>().Play ();
		} else {
			m_animator.SetBool ("Moving", false);

            if (m_playerSounds != null) //Need to stop playing audio for movement
                if (m_playerSounds.m_movementAudio.GetComponent<AudioSource>().isPlaying)
				    m_playerSounds.m_movementAudio.GetComponent<AudioSource>().Stop ();
		}

		if (!m_playerController.m_CollisionInfo.bottom && !m_playerController.m_CollisionInfo.top && !m_playerController.m_CollisionInfo.left && !m_playerController.m_CollisionInfo.right)// Falling animation
            m_animator.SetBool ("InAir", true);
		else
			m_animator.SetBool ("InAir", false);

		if ((m_playerController.m_CollisionInfo.left || m_playerController.m_CollisionInfo.right) && !m_playerController.m_CollisionInfo.bottom && !m_hitWall) {//hit side of wall
			m_hitWall = true;
			//Decide how to place effect
			int wallDirection = (m_playerController.m_CollisionInfo.left) ? -1 : 1; // Checks which direction the player is colliding with wall

			if (GetComponent<ColourController> ().m_firstBulletSlot)
            {
				m_currentHitWallEffect = Instantiate (m_hitWallEffect [0], transform.TransformPoint (m_hitWallEffectSpawnPos * wallDirection), Quaternion.identity);
            }
			else
            {
				m_currentHitWallEffect = Instantiate (m_hitWallEffect [1], transform.TransformPoint (m_hitWallEffectSpawnPos * wallDirection), Quaternion.identity);
            }

            //play wallSlide audio
            if (!m_playerSounds.m_wallSlideAudio.GetComponent<AudioSource>().isPlaying)
                m_playerSounds.m_wallSlideAudio.GetComponent<AudioSource>().Play();

            //Start timer to cause effect to follow player
            StartCoroutine (PauseEffectFollow (0.1f, m_currentHitWallEffect));
		}

        else
			m_hitWall = false;

        //stop wallSlide audio when not on walls
        if((!m_playerController.m_CollisionInfo.left && !m_playerController.m_CollisionInfo.right) || m_playerController.m_CollisionInfo.bottom)
        {
            if (m_playerSounds.m_wallSlideAudio.GetComponent<AudioSource>().isPlaying)
                m_playerSounds.m_wallSlideAudio.GetComponent<AudioSource>().Stop();
        }
            
	}

    //--------------------------------------------------------------------------------------
    // Have effect follow an object
    //
    // Param:
    //		delay: how long effect should follow player for
    //		effectHolder: parent for effect to follow
    //--------------------------------------------------------------------------------------
    IEnumerator PauseEffectFollow (float delay, GameObject effectHolder)
	{
		yield return new WaitForSeconds (delay);
		effectHolder.transform.parent = null;
		Destroy (effectHolder, 1.0f);
		effectHolder = null;
	}
}
