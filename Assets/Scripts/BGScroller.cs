using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	public float scrollSpeed;

	private Vector2 savedOffset;
	private Renderer rend;

	
	void Start () {
		rend = GetComponent<Renderer>();
		savedOffset = rend.sharedMaterial.GetTextureOffset ("_MainTex");
	}
	
	void Update () {
		//Get updating float to use as factor for poistion, create a vector2 and assign. 
		float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
		Vector2 offset = new Vector2 (x, 0);
		rend.material.SetTextureOffset ("_MainTex", offset);

	}

	void OnDisable () {
		rend.sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
	}
}
