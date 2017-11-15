using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerHealth : MonoBehaviour
{
	private GameObject m_otherPlayer = null;

	public XboxController controller;

	public bool isReviving = false;

	public float reviveTime = 2;
	public float timer = 0;

	public int healthGivenByPickup = 3;

	public float deathTimer = 0;
	public float deathTime = 2;

	public GameObject m_playerDeathEffect;
	public Vector3 m_playerDeathEffectOffset = Vector3.zero;

	public GameObject m_playerGhost = null;
	public Vector3 m_playerGhostOffset = Vector3.zero;
	private GameObject m_playerGhostHolder = null;

	//Player components
	private PlayerSounds m_playerSounds = null;

	// Use this for initialization
	void Start ()
	{
		isReviving = false;

		if (!GameObject.FindWithTag ("GameController").GetComponent<GameManager> ().m_singlePlayer) {
			//Case first player
			if (GetComponent<Player> ().isFirstPlayer)
				m_otherPlayer = GameObject.FindWithTag ("GameController").GetComponent<GameManager> ().m_player2;

			//Case second player
			if (!GetComponent<Player> ().isFirstPlayer)
				m_otherPlayer = GameObject.FindWithTag ("GameController").GetComponent<GameManager> ().m_player1;
		}

		m_playerSounds = GetComponent<PlayerSounds> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (GetComponent<Player> ().IsDead () && m_playerGhostHolder == null) {
			Destroy (Instantiate (m_playerDeathEffect, transform.TransformPoint (m_playerDeathEffectOffset), Quaternion.identity, transform), 5.0f);
			m_playerGhostHolder = Instantiate (m_playerGhost, transform.TransformPoint (m_playerGhostOffset), Quaternion.identity, transform);
			GetComponent<PlayerSounds> ().m_deathAudio.GetComponent<AudioSource> ().Play (); //Play death sound for player
			//Set player to be transparent
			this.gameObject.GetComponent<Player> ().m_childRenderer.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = false;
		} else if (!GetComponent<Player> ().IsDead () && m_playerGhostHolder != null) {
			//Set player to not be transparent
			this.gameObject.GetComponent<Player> ().m_childRenderer.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = true;
			Destroy (m_playerGhostHolder);
		}

		if (isReviving && XCI.GetButton ((XboxButton.X), controller) && !GetComponent<Player> ().IsDead () && m_otherPlayer.GetComponent<Player> ().IsDead ()) {
			timer += Time.deltaTime;

			if (timer >= reviveTime) {
				timer = 0;
				//Revivie other player, play sound
				m_otherPlayer.GetComponent<Player> ().SetHealth (2);
				m_otherPlayer.GetComponent<PlayerSounds> ().m_reviveAudio.GetComponent<AudioSource> ().Play ();
			}

			//Play Audio for respawn
			if (!m_playerSounds.m_respawnAudio.GetComponent<AudioSource> ().isPlaying)
				m_playerSounds.m_respawnAudio.GetComponent<AudioSource> ().Play ();
		}

		if (XCI.GetButtonUp ((XboxButton.B), controller)) {
			timer = 0;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (m_otherPlayer != null) {
           
			if (other.gameObject.tag == "Player" && m_otherPlayer.GetComponent<Player> ().IsDead ()) {
				Debug.Log ("hitplayer");
				isReviving = true;
			}

			if (other.gameObject.tag == "HealthPickup") {
				Destroy (other.gameObject);
				this.GetComponent<Player> ().ChangeHealth (healthGivenByPickup);
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (m_otherPlayer != null) {
			if (other.gameObject.tag == "Player" && m_otherPlayer.GetComponent<Player> ().IsDead ()) {
				isReviving = false;
				timer = 0;
			}
		}
	}
}
