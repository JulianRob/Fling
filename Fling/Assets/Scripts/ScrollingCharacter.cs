using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCharacter : MonoBehaviour {
	
	private MeshRenderer mr2d;
	float y = 0;
	float x = 0;

	public float speed;

	// Use this for initialization
	void Start () 
	{
		mr2d = GetComponent<MeshRenderer> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey("w")) 
		{
			Vector2 offset = new Vector2 (x,y);
			mr2d.material.mainTextureOffset = offset;
			y -= .01f;
		}

		if (Input.GetKey("a")) 
		{
			Vector2 offset = new Vector2 (x,y);
			mr2d.material.mainTextureOffset = offset;
			x += .01f;
		}

		if (Input.GetKey("s")) 
		{
			Vector2 offset = new Vector2 (x,y);
			mr2d.material.mainTextureOffset = offset;
			y += .01f;
		}

		if (Input.GetKey("d")) 
		{
			Vector2 offset = new Vector2 (x,y);
			mr2d.material.mainTextureOffset = offset;
			x -= .01f;
		}
	}
}
