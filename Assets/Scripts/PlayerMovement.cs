using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour { 

	public static PlayerMovement instance;

	public float maxSpeed = 1;
	public float turnStrength;
	public Vector3 startPosition;

	private Rigidbody2D body;
	private Renderer rend;
	private bool facingUp;
	private Component[] particleChildren;

	void OnEnable() {
		GameController.GameOver += GameOver;
		GameController.StartGame += StartGame;
	}
	
	void Awake() {
		if (instance == null)
			
			//if not, set instance to this
			instance = this;
		
		//If instance already exists and it's not this:
		else if (instance != this)
			
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
		rend = GetComponent<Renderer>();
		body = GetComponent<Rigidbody2D>();
		particleChildren = GetComponentsInChildren<ParticleSystem>(); 
	}

	void Start() {
		facingUp = false;
		body.isKinematic = true;
		rend.enabled = false;
		enabled = false;
	}

	void Update() {
		transform.Translate(Vector3.up * Time.deltaTime * maxSpeed);
		if (Input.GetKeyDown (KeyCode.Space))
		{
			Flip();
		}

		if ((transform.eulerAngles.z < 180) || (transform.eulerAngles.z > 360))
		{
			body.angularVelocity = 0;
		}			
	}

	void Flip () {
		if (!facingUp)
		{
			body.angularVelocity = 0;
			body.AddTorque (turnStrength);
			facingUp = true;
		}
		else
		{
			body.angularVelocity = 0;
			body.AddTorque (turnStrength * -1);
			facingUp = false;
		}
	}

	void TurnEnginesOn() {
		foreach (ParticleSystem particles in particleChildren)
		{
			particles.enableEmission = true;
		}
	}

	void TurnEnginesOff() {
		foreach (ParticleSystem particles in particleChildren)
		{
			particles.enableEmission = false;
		}
	}

	void StartGame() {
		TurnEnginesOn();
		transform.position = startPosition;
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 270f);
		body.angularVelocity = 0;
		body.isKinematic = false;
		rend.enabled = true;
		enabled = true;
	}

	void GameOver() {
		TurnEnginesOff();
		body.isKinematic = true;
		rend.enabled = false;
		enabled = false;
	}

}
