using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

	private MeshRenderer mr2d;

	public float speed;

	// Use this for initialization
	void Start () 
	{
		mr2d = GetComponent<MeshRenderer> ();
		speed = 0.1f;
	}

	// Update is called once per frame
	void Update ()
	{
		Vector2 offset = new Vector2 (0,Time.time*speed);
		mr2d.material.mainTextureOffset = offset;
	}
}
