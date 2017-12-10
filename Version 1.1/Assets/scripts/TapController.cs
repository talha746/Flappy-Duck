using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TapController : MonoBehaviour {

	public delegate void PlayerDelegate ();
	public static event PlayerDelegate OnPlayerDied;
	public static event PlayerDelegate OnPlayerScored;

	public float tapForce = 10;
	public float tiltsSmooth = 5;  //amount the duck tilts downwards
	public Vector3 startPos;   //where to set duck back to

	Rigidbody2D rigidbody;
	Quaternion downRotation;
	Quaternion forwardRotation; 

	GameManager game;  //reference to gamemanager

	void Start() {
		rigidbody = GetComponent<Rigidbody2D>();
		downRotation = Quaternion.Euler (0, 0, -90);
		forwardRotation = Quaternion.Euler (0, 0, 35);
		game = GameManager.Instance;
		rigidbody.simulated = false;
	}

	void OnEnable() {
		GameManager.OnGameStarted += OnGameStarted;
		GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
	}

	void OnDisable() {
		GameManager.OnGameStarted -= OnGameStarted;
		GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
	}

	void OnGameStarted() {
		rigidbody.velocity = Vector3.zero; //set velocity back to zero at start
		rigidbody.simulated = true;
	}

	void OnGameOverConfirmed() {
		transform.localPosition = startPos;
		transform.rotation = Quaternion.identity;
	}

	void Update() {
		if (game.GameOver) return; //no updating if gameover state is true

		if (Input.GetMouseButtonDown (0)) {   //0 means left click or tap on mobile
			transform.rotation = forwardRotation;
			rigidbody.velocity = Vector3.zero;
			rigidbody.AddForce (Vector2.up * tapForce, ForceMode2D.Force);
		}

		transform.rotation = Quaternion.Lerp (transform.rotation, downRotation, tiltsSmooth * Time.deltaTime);  //source value going to target value in delta time
	}

	void OnTriggerEnter2D(Collider2D col) {
		//check if in scorezone or deadzone

		if (col.gameObject.tag == "ScoreZone") {
			//register a score event
			OnPlayerScored();  //event sent to gamemanager
			//play a sound

		}

		if (col.gameObject.tag == "DeadZone") {
			rigidbody.simulated = false; //freeze duck
			//register a dead event
			OnPlayerDied();  //event sent to gamemanager
			//play a sound
		}
	}

}
