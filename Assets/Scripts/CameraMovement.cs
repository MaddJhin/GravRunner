using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float xSmooth = 1f;
	public float ySmooth = 1f;
	public float xOffset, yOffset;

	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float targetX = Mathf.Lerp (transform.position.x, player.position.x + xOffset, xSmooth);
		float targetY = Mathf.Lerp (transform.position.y, player.position.y + yOffset, ySmooth);

		transform.position = new Vector3 (targetX, targetY, transform.position.z);
	}
}
