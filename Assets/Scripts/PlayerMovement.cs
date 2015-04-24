using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 1;
	public float turnStrength;

	private Rigidbody2D body;
	private bool facingUp;

	// Use this for initialization
	void Start () {
		facingUp = false;
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
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
}
