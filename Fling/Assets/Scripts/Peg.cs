using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.position = new Vector3(transform.position.x,transform.position.y-0.1f,transform.position.z);
		if (transform.position.y <= -7f) 
		{
			Destroy (gameObject);
		}
	}
}
